using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace AssetMan_WebApp.ViewModels.Authentication
{
    public class SetUpRolesViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;
        public SetUpRolesViewModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.config = config;
            //
        
        }

        public override Task PreRender()
        {
            //Khi truy cập trang này nó tự tạo:
            

            return base.PreRender();
        }

        public async Task SetUpAuth()
        {
            //Create roles, lấy ở appsettings:
            foreach (string rol in this.config.GetSection("Roles").Get<List<string>>())
            {
                if (!await roleManager.RoleExistsAsync(rol))
                {
                    await roleManager.CreateAsync(new IdentityRole(rol));
                }
            }
            //Xác định SuperAdmin
            var user = await userManager.FindByNameAsync(config.GetValue<string>("SuperAdminUser"));//Đọc từ appsettings.json xem đã có tên đó chưa

            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "SuperAdmin");
            }    

        }

    }

}

