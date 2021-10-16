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
    public class UpdateFinanceCategoryUseCase : IUpdateFinanceCategoryUseCase
    {
        private readonly IFinanceCategoryRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public UpdateFinanceCategoryUseCase(IFinanceCategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            

           

        }

        public async Task Execute(CategoryInFinanceDTO category)
        {         
            await categoryRepository.UpdateCategory(mapper.Map<CategoryInFinanceDTO, CategoryInFinance>(category));
        }
    }
}
