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
    public class GetAllLocationsUseCase : IGetAllLocationsUseCase
    {
        private readonly ILocationRepository locationRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetAllLocationsUseCase(ILocationRepository categoryRepository)
        {
            this.locationRepository = categoryRepository;
            

        }
        public async Task<List<LocationDTO>> Execute()
        {
                       
                return await Task.Run(() =>  locationRepository.GetAllLocations().Result.Select(
                    addBT => mapper.Map<Location, LocationDTO>(addBT)).ToList());

        }
    }
}
