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
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public UpdateCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
           
          

        }

        public async Task Execute(CategoryDTO category)
        {
           
            await categoryRepository.UpdateCategory(mapper.Map<CategoryDTO, Category>(category));
        }
    }
}
