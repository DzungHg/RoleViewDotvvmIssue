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
    public class GetAllFinanceCategoriesUseCase : IGetAllFinanceCategoriesUseCase
    {
        private readonly IFinanceCategoryRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetAllFinanceCategoriesUseCase(IFinanceCategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            
          

        }
        public async Task<List<CategoryInFinanceDTO>> Execute()
        {
          
                var finnishingMachines = await Task.Run(()=> categoryRepository.GetAllCategories().Result.Select(
                    addBT => mapper.Map<CategoryInFinance, CategoryInFinanceDTO>(addBT)).ToList());


                return finnishingMachines;
         
        }

      
    }
}
