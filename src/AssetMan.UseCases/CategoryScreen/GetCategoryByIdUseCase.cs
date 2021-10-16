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
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        private readonly IMapper mapper = MapperUtils.Mapper();
        public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            //Phải đưa chuỗi kết nối dabase vô đây:            
          

        }

        public async Task<CategoryDTO> Execute(string id)
        {
            return  mapper.Map<Category, CategoryDTO>( await categoryRepository.GetCategoryById(id));

           
        }

        
    }
}
