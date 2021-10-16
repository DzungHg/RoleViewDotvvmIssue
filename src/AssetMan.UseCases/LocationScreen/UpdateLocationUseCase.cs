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
    public class UpdateLocationUseCase : IUpdateLocationUseCase
    {
        private readonly ILocationRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public UpdateLocationUseCase(ILocationRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
           
           

        }

        public async Task Execute(LocationDTO category)
        {
            
            await categoryRepository.UpdateLocation(mapper.Map<LocationDTO, Location>(category));
        }
    }
}
