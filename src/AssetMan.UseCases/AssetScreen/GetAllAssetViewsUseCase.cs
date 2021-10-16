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
    public class GetAllAssetViewsUseCase : IGetAllAssetViewsUseCase
    {
        private readonly IAssetRepository assetRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetAllAssetViewsUseCase(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
            

        }

        public async Task<List<AssetViewDTO>> Execute()
        {
           return await Task.Run(() => assetRepository.GetAllAssetViews().Result.Select(
                    addBT => mapper.Map<AssetView, AssetViewDTO>(addBT)).ToList());


            
        }
    }
}
