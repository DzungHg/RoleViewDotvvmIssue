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
    public class GetAllContactsUseCase : IGetAllContactsUseCase
    {
        private readonly IContactRepository locationRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetAllContactsUseCase(IContactRepository categoryRepository)
        {
            this.locationRepository = categoryRepository;
            //Phải đưa chuỗi kết nối dabase vô đây:            
         


        }
        public async Task<List<ContactDTO>> Execute()
        {
          
                var finnishingMachines = await  Task.Run(()=> locationRepository.GetAllContacts().Result.Select(
                    addBT => mapper.Map<Contact, ContactDTO>(addBT)).ToList());


                return finnishingMachines;
         
        }
    }
}
