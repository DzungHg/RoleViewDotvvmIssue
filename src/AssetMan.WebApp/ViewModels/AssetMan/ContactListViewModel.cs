using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.BusinessPack.Controls;
using AssetMan.UseCases.ContactScreen;
using AssetMan.UseCases.DTO;

namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class ContactListViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IGetAllContactsUseCase contactViewAllUseCase;

        
        public ContactListViewModel(IGetAllContactsUseCase contactViewAllUseCase)
        {
            this.contactViewAllUseCase = contactViewAllUseCase;
           
        }

    
        public BusinessPackDataSet<ContactDTO> Contacts { get; set; } = new BusinessPackDataSet<ContactDTO>
        {
            PagingOptions = {
                    PageSize = 20
                },
            SortingOptions =
                {
                    SortExpression = nameof(ContactDTO.FirstName),
                    SortDescending = true
                }
        };
        public override Task PreRender()
        {
            if (Contacts.IsRefreshRequired)
            {
               
                    Contacts.Items = contactViewAllUseCase.Execute().Result;
               
            }

            return base.PreRender();
        }

      


        //Click sửa
        public void ViewContact(int id)
        {
            Context.RedirectToRoute("ContactDetail", new { Id = id });
        }
       

    }
}

