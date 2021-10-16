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

namespace AssetMan.UseCases.AssetScreen
{
    public class CreateAssetUseCase : ICreateAssetUseCase
    {
        private readonly IAssetRepository assetRepository;
        private readonly IMapper mapper = MapperUtils.Mapper();
        public CreateAssetUseCase(IAssetRepository categoryRepository)
        {
            this.assetRepository = categoryRepository;
            

           

        }
     

        public async Task<string> Execute(AssetDTO categoryDTO)
        {
            Asset asset;

            asset = mapper.Map<AssetDTO, Asset>(categoryDTO);
            return await assetRepository.CreateAsset(asset);
        }

       
    }
}
