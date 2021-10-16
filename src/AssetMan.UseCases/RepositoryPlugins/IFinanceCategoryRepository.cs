using AssetMan.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMan.UseCases.RepositoryPlugins
{
    public interface IFinanceCategoryRepository
    {
       
        Task<List<CategoryInFinance>> GetAllCategories();

        Task CreateCategory(CategoryInFinance category);
        Task UpdateCategory(CategoryInFinance category);

        Task<CategoryInFinance> GetCategoryById(string id);
        Task RemoveCategory(string id);
        Task<bool> IsCategoryIDAvailable(string id);
    }
}
