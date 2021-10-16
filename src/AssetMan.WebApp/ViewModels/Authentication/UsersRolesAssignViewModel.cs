using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using AssetMan_WebApp.Models;

using AssetMan_WebApp.DAL;


namespace AssetMan_WebApp.ViewModels.Authentication
{

    public class UsersRolesAssignViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;

        public UsersRolesAssignViewModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.config = config;

        }

        public override Task PreRender()
        {
            //this.UsersRolesTable = GetUsersRolesTable();

            return base.PreRender();
        }

        public List<UserWithRoles> UserWithRolesList => this.GetUserWithRolesList();

        private List<UserWithRoles>GetUserWithRolesList ()
        {
            List<UserWithRoles> list = new();
            var roleStrs = "";
            foreach (var uSer in userManager.Users)
            {
                roleStrs = "";
                
                foreach (var roleStr in userManager.GetRolesAsync(uSer).Result)
                {
                    roleStrs += $"{roleStr};";
                }

                UserWithRoles uWR = new UserWithRoles
                {
                    UserName = uSer.UserName,
                    RoleList = roleStrs

                };

                list.Add(uWR);
            }    

            return list;
        }
        public string[,] UsersRolesTable { get; set; }


        private string[,] GetUsersRolesTable()
        {
            var arrayXs = this.userManager.Users.ToList();
            var arrayYs = this.roleManager.Roles.ToList();

            string[,] usersRolesTable = null;

            if (arrayXs.Count > 0 & arrayYs.Count > 0)
            {
                usersRolesTable = new string[arrayXs.Count + 1, arrayYs.Count +1];//Chừa cột title và hàng title
            }
            else return usersRolesTable;

            //Qua, tạo header hàng, cột
            for (int i = 0; i == arrayXs.ToArray().Count(); i++)
            {
                usersRolesTable[i+1, 0] = arrayXs.ToArray()[i].UserName;
            }
            //Cột
            for (int i = 0; i == arrayYs.ToArray().Count(); i++)
            {
                usersRolesTable[0, i + 1] = arrayYs.ToArray()[i].Name;

            }
            //Điền hết nội dung hàng cột là "false hết;
            for (int i = 1; i < usersRolesTable.GetLength(0); i++)
            {
                usersRolesTable[i, 0] = "false";
                for (int y = 1; y < usersRolesTable.GetLength(1); y++)
                {
                    usersRolesTable[i, y] = "false";
                }
            }

            /// Điền nội dung bản dãy: lấy roles của từng user rồi dò thể hàng của user đó theo cột 
            /// nếu role có đánh true, không đáy false.
            List<string> userRoles = new ();

            for (int i = 1; i < usersRolesTable.GetLength(0); i++)
            {
                userRoles = this.userManager.GetRolesAsync(arrayXs.FirstOrDefault(x => x.UserName == usersRolesTable[i, 0])).Result.ToList();
                //Dò List userRole để điền
                foreach (var uR in userRoles)
                {
                    //Dò trên hàng 0, cột 1 -> hết xem sự xuất hiện role thì đánh dấu true
                    for (int y = 1; y < usersRolesTable.GetLength(1);  y++)
                    {
                        if (usersRolesTable[0,y] == uR)
                        {
                            usersRolesTable[i, y] = "true";
                        }                        
                    }
                }    
            }

            return usersRolesTable;


        }
    }
}

