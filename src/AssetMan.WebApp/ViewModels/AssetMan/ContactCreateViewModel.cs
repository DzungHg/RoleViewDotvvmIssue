using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using AssetMan.UseCases.ContactScreen;
using AssetMan.UseCases.DTO;


namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class ContactCreateViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly ICreateContactUseCase contactCreateUseCase;
       

        public ContactCreateViewModel(ICreateContactUseCase contactCreateUseCase)
        {

            this.contactCreateUseCase = contactCreateUseCase;
           

        }
      
        //
        public ContactDTO Contact { get; set; } = new ContactDTO()
        {
          
        };
        public string ActiveTabKey { get; set; } = "FirstTab";

        //Valid ation
        public string ValidationgMessagesText { get; set; }
        public List<string> ValidationgMessages { get; set; } = new();
        public bool IsDataValided()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.Contact.FirstName))
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu Tên");
            }
            



            return result;
        }
        public void ThemMoiContact()
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

            this.contactCreateUseCase.Execute(this.Contact);

            Context.RedirectToRoute("ContactList");
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

