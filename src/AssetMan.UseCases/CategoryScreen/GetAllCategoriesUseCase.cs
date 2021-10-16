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

namespace AssetMan.UseCases.CategoryScreen
{
    public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetAllCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
                        

        }
        public async Task<List<CategoryDTO>> Execute()
        {
          
                var finnishingMachines = await Task.Run(()=> categoryRepository.GetAllCategories().Result.Select(
                    addBT => mapper.Map<Category, CategoryDTO>(addBT)).ToList());


                return finnishingMachines;
         
        }
    }
}
