using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AssetMan.CoreBusiness;
using AssetMan.UseCases.DTO;
using AssetMan.UseCases.Helpers;
using AssetMan.UseCases.RepositoryPlugins;

namespace AssetMan.UseCases.ContactScreen
{
    public class UpdateContactUseCase : IUpdateContactUseCase
    {
        private readonly IContactRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public UpdateContactUseCase(IContactRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
           

        }

        public async Task Execute(ContactDTO category)
        {
            Contact addBook;

            addBook = mapper.Map<ContactDTO, Contact>(category);
            await categoryRepository.UpdateContact(addBook);
        }
    }
}
