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
    public class ContactEditViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IContactUpdateUseCase contactUpdateUseCase;
        private readonly IContactGetByIdUseCase contactGetByIdUseCase;

        public ContactEditViewModel(IContactUpdateUseCase contactUpdateUseCase, IContactGetByIdUseCase contactGetByIdUseCase)
        {

            this.contactUpdateUseCase = contactUpdateUseCase;
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
        public string ActiveTabKey { get; set; } = "FirstTab";
        //Valid ation
        public string ValidationMessagesText { get; set; }
        public List<string> ValidationMessages { get; set; } = new();
        public bool IsDataValided()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.Contact.FirstName))
            {
                result = false;
                this.ValidationMessages.Add("Thiếu Tên");
            }



            return result;
        }


        public void EditContact()
        {
            //Check validation
            if (!this.IsDataValided())
            {
                this.ValidationMessagesText = "Lỗi: ";
                foreach (var str in this.ValidationMessages)
                {
                    this.ValidationMessagesText += string.Format("{0} \n", str);
                }

                return;
            }
            //Sửa
            this.contactUpdateUseCase.Execute(this.Contact);
            //Roouting lại
            Context.RedirectToRoute("ContactDetail", new { id = this.Contact.ID } );
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void Huy()
        {
            Context.RedirectToRoutePermanent("ContactDetail", new { id = this.Contact.ID });
        }
      
    }
}

