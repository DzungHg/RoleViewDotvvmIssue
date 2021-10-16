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
    public class CreateContactUseCase : ICreateContactUseCase
    {
        private readonly IContactRepository categoryRepository;

      
        private readonly IMapper mapper = MapperUtils.Mapper();
        public CreateContactUseCase(IContactRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
          

           

        }
     

        public async Task Execute(ContactDTO categoryDTO)
        {
            Contact category;

            category = mapper.Map<ContactDTO, Contact>(categoryDTO);
            await categoryRepository.CreateContact(category);
        }

       
    }
}
