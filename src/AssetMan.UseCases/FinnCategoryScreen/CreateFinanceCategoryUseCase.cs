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
    public class CreateFinanceCategoryUseCase : ICreateFinanceCategoryUseCase
    {
        private readonly IFinanceCategoryRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public CreateFinanceCategoryUseCase(IFinanceCategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            

           

        }
     

        public async Task Execute(CategoryInFinanceDTO categoryDTO)
        {
            await categoryRepository.CreateCategory(mapper.Map<CategoryInFinanceDTO, CategoryInFinance>(categoryDTO));
        }

       
    }
}
