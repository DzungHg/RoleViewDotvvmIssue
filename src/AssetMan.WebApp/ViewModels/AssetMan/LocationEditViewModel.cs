using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using AssetMan.UseCases.Interfaces;
using AssetMan.UseCases.DTO;
using AssetMan.UseCases.enums;

namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class LocationEditViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly ILocationUpdateUseCase locationUpdateUseCase;
        private readonly ILocationGetByIdUseCase locationGetByIdUseCase;

        public LocationEditViewModel(ILocationUpdateUseCase locationCreateUseCase, ILocationGetByIdUseCase locationGetByIdUseCase)
        {

            this.locationUpdateUseCase = locationCreateUseCase;
            this.locationGetByIdUseCase = locationGetByIdUseCase;
            

        }

        public override Task PreRender()
        {
            
            int id = 0;
            if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
            {
                this.Location = this.locationGetByIdUseCase.Execute(id);
            }

            //int id = Convert.ToInt32(Context.Parameters["id"]);

            //


            return base.PreRender();
        }


        //
        public LocationDTO Location { get; set; }

        //Valid ation
        public string ValidationMessagesText { get; set; }
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





        public void EditLocation()
        {
            //Check validation
            if (!this.IsDataValided())
            {
                this.ValidationMessagesText = "Lỗi: ";
                foreach (var str in this.ValidationgMessages)
                {
                    this.ValidationMessagesText += string.Format("{0} \n", str);
                }

                return;
            }

            this.locationUpdateUseCase.Execute(this.Location);

            Context.RedirectToRoute("LocationDetail", new { id = this.Location.Location_SEQ } );
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void Huy()
        {
            Context.RedirectToRoutePermanent("LocationDetail", new { id = this.Location.Location_SEQ });
        }
      
    }
}

