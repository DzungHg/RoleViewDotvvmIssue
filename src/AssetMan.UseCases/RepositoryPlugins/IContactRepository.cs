using AssetMan.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMan.UseCases.RepositoryPlugins
{
    public interface IContactRepository
    {
       
        Task<List<Contact>> GetAllContacts();

        Task CreateContact (Contact contact);
        Task UpdateContact(Contact contact);

        Task<Contact> GetContactById(int id);
        Task RemoveContact(int id);
      
    }
}
