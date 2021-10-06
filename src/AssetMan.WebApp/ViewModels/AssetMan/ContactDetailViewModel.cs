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
    public class ContactDetailViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IContactGetByIdUseCase contactGetByIdUseCase;
       

        public ContactDetailViewModel(IContactGetByIdUseCase contactGetByIdUseCase)
        {

            this.contactGetByIdUseCase = contactGetByIdUseCase;
            

        }

        public override Task PreRender()
        {
            
            int id = 0;
            if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
            {
                this.Contact = contactGetByIdUseCase.Execute(id);
            }

            //int id = Convert.ToInt32(Context.Parameters["id"]);

            //


            return base.PreRender();
        }


        //
        public ContactDTO Contact { get; set; }
       

      

       

        
        public void EditContact(int iD)
        {
            

            Context.RedirectToRoute("ContactEdit", new { id = iD } );
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void QuayLaiDanhSach()
        {
            Context.RedirectToRoute("ContactList");
        }
    }
}

