using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using AssetMan.UseCases.Interfaces;
using AssetMan.UseCases.DTO;



namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class LocationCreateViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly ILocationCreateUseCase locationCreateUseCase;
       

        public LocationCreateViewModel(ILocationCreateUseCase locationCreateUseCase)
        {

            this.locationCreateUseCase = locationCreateUseCase;
           

        }
      
        //
        public LocationDTO Location { get; set; } = new LocationDTO()
        {
          
        };

      
        //Valid ation
        public string ValidationgMessagesText { get; set; }
        public List<string> ValidationgMessages { get; set; } = new();
        public bool IsDataValided()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.Location.Location_Name))
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu tên Tài sản");
            }

          

            return result;
        }
        public void ThemMoiLocation()
        {
            //Check validation
            if (!this.IsDataValided())
            {
                this.ValidationgMessagesText = "Lỗi: ";
                foreach (var str in this.ValidationgMessages)
                {
                    this.ValidationgMessagesText += string.Format("{0} \n", str);
                }

                return;
            }

            this.locationCreateUseCase.Execute(this.Location);

            Context.RedirectToRoute("LocationList");
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void QuayLaiDanhSach()
        {
            Context.RedirectToRoute("LocationList");
        }
    }
}

