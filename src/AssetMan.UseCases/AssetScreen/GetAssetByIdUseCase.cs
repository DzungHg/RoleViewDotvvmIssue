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
    public class GetAssetByIdUseCase : IGetAssetByIdUseCase
    {
        private readonly IAssetRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetAssetByIdUseCase(IAssetRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
           
            

        }

        public async Task<AssetDTO> Execute(int id)
        {
            var categoryDTO = mapper.Map<Asset, AssetDTO>( await categoryRepository.GetAssetById(id));

            return categoryDTO;
        }

        
    }
}
