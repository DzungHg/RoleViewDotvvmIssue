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
    public class LocationDetailViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly ILocationGetByIdUseCase locationGetByIdUseCase;


        public LocationDetailViewModel(ILocationGetByIdUseCase  locationGetByIdUseCase)
        {

            this.locationGetByIdUseCase = locationGetByIdUseCase;
            

        }

        public override Task PreRender()
        {
            
            int id = 0;
            if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
            {
                this.Location = locationGetByIdUseCase.Execute(id);
            }

            //int id = Convert.ToInt32(Context.Parameters["id"]);

            //


            return base.PreRender();
        }


        //
        public LocationDTO Location { get; set; }
       

      

       

        
        public void EditLocation(int iD)
        {
            

            Context.RedirectToRoute("LocationEdit", new { id = iD } );
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

