using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetMan.CoreBusiness;
using AssetMan.UseCases.RepositoryPlugins;
using AssetMan.Plugins.Repository.SqliteDb.DataAccess;

namespace AssetMan.Plugins.Repository.SqliteDb
{
    public class FinanceCategoryRepository : IFinanceCategoryRepository
    {

        private SqlDataAcess db = new SqlDataAcess();

        private readonly string ConnectionString = DataConnects.GetConnectionString();



        #region Listing
        //Listing
        public async Task<List<CategoryInFinance>> GetAllCategories()
        {
            string sql = "SELECT * FROM CategoriesInFinance";
            return await db.LoadData<CategoryInFinance, dynamic>(sql, new { }, ConnectionString);
        }

        //Get CategoryInFinance
        public async Task<CategoryInFinance> GetCategoryById(string id)
        {
            string sql = "SELECT * FROM CategoriesInFinance WHERE Category_ID = @Category_ID";
            CategoryInFinance output;
            output = await Task.Run(()=> db.LoadData<CategoryInFinance, dynamic>(sql, new { Category_ID = id }, ConnectionString).Result.FirstOrDefault());

            if (output == null)
            {
                //Do something

                return null;
            }

            return output;

        }
        //write 
        public async Task CreateCategory(CategoryInFinance category)
        {
            string sql = "INSERT INTO CategoriesInFinance (Category_ID, Category_Name)"
                + " VALUES (@Category_ID, @Category_Name);";

            await db.SavingData(sql, new
            {
                category.Category_ID,
                category.Category_Name
             }, ConnectionString);


        }
        //update Category 
        public async Task UpdateCategory(CategoryInFinance asset)
        {
            string sql = "UPDATE CategoriesInFinance SET Category_Name = @Category_Name"
                + " WHERE Category_ID = @Category_ID ";

            await  db.SavingData(sql, asset, ConnectionString);

        }

        //remove Category 
        public async Task RemoveCategory(string id)
        {
            string sql = "DELETE from CategoriesInFinance WHERE Category_ID = @Category_ID;";

            await db.SavingData(sql, new { Category_ID = id }, ConnectionString);

        }
        #endregion
        //Hỗ trợ

        public async Task<bool> IsCategoryIDAvailable(string id)
        {
            bool result = true;
            string sql = "SELECT Category_ID FROM CategoriesInFinance WHERE Category_ID = @Category_ID";
           
            var output = await Task.Run(() => db.LoadData<string, dynamic>(sql, new { Category_ID = id }, ConnectionString).Result.FirstOrDefault());

            if (!string.IsNullOrEmpty(output))
                result = false;
           

            return result;

        }

     
    }
}
