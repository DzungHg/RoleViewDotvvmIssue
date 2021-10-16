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

namespace AssetMan.UseCases.AssetScreen
{
    public class GetAssetsByCategoryUseCase : IGetAssetsByCategoryUseCase
    {
        private readonly IAssetRepository locationRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetAssetsByCategoryUseCase(IAssetRepository categoryRepository)
        {
            this.locationRepository = categoryRepository;
            

           

        }
        public async Task<List<AssetViewDTO>> Execute(string categoryId)
        {
          
                var finnishingMachines = await Task.Run(() => locationRepository.GetAllAssetViewsByCategory(categoryId).Result.Select(
                    addBT => mapper.Map<AssetView, AssetViewDTO>(addBT)).ToList());


                return finnishingMachines;
         
        }
    }
}
