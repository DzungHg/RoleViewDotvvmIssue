using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AssetMan.CoreBusiness;
using AssetMan.UseCases.DTO;

using AssetMan.UseCases.RepositoryPlugins;
using AssetMan.UseCases.Helpers;

namespace AssetMan.UseCases.ContactScreen
{
    public class GetContactByIdUseCase : IGetContactByIdUseCase
    {
        private readonly IContactRepository contactRepository;

      
        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetContactByIdUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
            

        }

        public async Task<ContactDTO> Execute(int id)
        {
            var contactDTO = mapper.Map<Contact, ContactDTO>(await contactRepository.GetContactById(id));

            return contactDTO;
        }

        
    }
}
