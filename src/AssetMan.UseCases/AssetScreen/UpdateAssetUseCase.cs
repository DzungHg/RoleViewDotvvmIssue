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
    public class UpdateAssetUseCase : IUpdateAssetUseCase
    {
        private readonly IAssetRepository assetRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public UpdateAssetUseCase(IAssetRepository categoryRepository)
        {
            this.assetRepository = categoryRepository;
          
            

        }

        public async Task<string> Execute(AssetDTO assetDTO)
        {
          
            return await assetRepository.UpdateAsset(mapper.Map<AssetDTO, Asset>(assetDTO));
        }
    }
}
