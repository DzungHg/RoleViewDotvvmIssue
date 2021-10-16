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
    public class GetLocationByIdUseCase : IGetLocationByIdUseCase
    {
        private readonly ILocationRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetLocationByIdUseCase(ILocationRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            

            

        }

        public async Task<LocationDTO> Execute(int id)
        {           
            return mapper.Map<Location, LocationDTO>( await categoryRepository.GetLocationById(id));
        }

        
    }
}
