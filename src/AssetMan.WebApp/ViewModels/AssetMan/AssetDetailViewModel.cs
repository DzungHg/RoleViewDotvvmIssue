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
    public class AssetDetailViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IAssetGetByIdUseCase ssetGetByIdUseCase;
       

        public AssetDetailViewModel(IAssetGetByIdUseCase assetGetByIdUseCase)
        {

            this.ssetGetByIdUseCase = assetGetByIdUseCase;
            

        }

        public override Task PreRender()
        {
            
            int id = 0;
            if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
            {
                this.Asset = ssetGetByIdUseCase.Execute(id);
            }

            //int id = Convert.ToInt32(Context.Parameters["id"]);

            //


            return base.PreRender();
        }


        //
        public AssetDTO Asset { get; set; }
       

        public string ActiveTabKey { get; set; } = "FirstTab";

       

        
        public void EditAsset(int iD)
        {
            

            Context.RedirectToRoute("AssetEdit", new { id = iD } );
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void QuayLaiDanhSach()
        {
            Context.RedirectToRoute("AssetList");
        }
    }
}

