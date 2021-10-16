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

namespace AssetMan.UseCases.LocationScreen
{
    public class CreateLocationUseCase : ICreateLocationUseCase
    {
        private readonly ILocationRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public CreateLocationUseCase(ILocationRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
           

        }
     

        public async Task Execute(LocationDTO categoryDTO)
        {
            await categoryRepository.CreateLocation(mapper.Map<LocationDTO, Location>(categoryDTO));
        }

       
    }
}
