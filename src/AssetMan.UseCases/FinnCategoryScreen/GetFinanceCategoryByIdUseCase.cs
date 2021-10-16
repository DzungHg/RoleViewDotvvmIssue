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

namespace AssetMan.UseCases.FinnCategoryScreen
{
    public class GetFinanceCategoryByIdUseCase : IGetFinanceCategoryByIdUseCase
    {
        private readonly IFinanceCategoryRepository categoryRepository;
        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetFinanceCategoryByIdUseCase(IFinanceCategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
           

           

        }

        public async Task<CategoryInFinanceDTO> Execute(string id)
        {
            return   mapper.Map<CategoryInFinance, CategoryInFinanceDTO>(await categoryRepository.GetCategoryById(id));

         
        }

        
    }
}
