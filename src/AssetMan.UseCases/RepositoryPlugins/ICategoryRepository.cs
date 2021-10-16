using AssetMan.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMan.UseCases.RepositoryPlugins
{
    public interface ICategoryRepository
    {
       
        Task<List<Category>> GetAllCategories();

        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);

        Task<Category> GetCategoryById(string id);
        Task RemoveCategory(string id);
        Task<bool> IsCategoryIDAvailable(string id);
    }
}
