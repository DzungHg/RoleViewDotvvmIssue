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
    public class CategoryRepository : ICategoryRepository
    {

        private SqlDataAcess db = new SqlDataAcess();

        private readonly string ConnectionString = DataConnects.GetConnectionString();

        /*public CategoryRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }*/

        #region Listing
        //Listing
        public async Task<List<Category>> GetAllCategories()
        {
            string sql = "SELECT * FROM Categories";
            return await db.LoadData<Category, dynamic>(sql, new { }, ConnectionString);
        }

        //Get Category
        public async Task<Category> GetCategoryById(string id)
        {
            string sql = "SELECT * FROM Categories WHERE Category_ID = @Category_ID";
            Category output;
            output = await Task.Run(() => db.LoadData<Category, dynamic>(sql, new { Category_ID = id }, ConnectionString).Result.FirstOrDefault());

            if (output == null)
            {
                //Do something

                return null;
            }

            return output;

        }
        //write 
        public async Task CreateCategory(Category category)
        {
            string sql = "INSERT INTO Categories (Category_ID, Category_Name)"
                + " VALUES (@Category_ID, @Category_Name);";

             await db.SavingData(sql, new
             {
                 category.Category_ID,
                 category.Category_Name
             }, ConnectionString);


        }
        //update Category 
        public async Task UpdateCategory(Category category)
        {
            string sql = "UPDATE Categories SET Category_Name = @Category_Name"
                + " WHERE Category_ID = @Category_ID ";

            await db .SavingData(sql, category, ConnectionString);

        }

        //remove Category 
        public async Task RemoveCategory(string  id)
        {
            string sql = "DELETE from Categories WHERE Category_ID = @Category_ID;";

            await db.SavingData(sql, new { Category_ID = id}, ConnectionString);

        }
        #endregion
        //Hỗ trợ

        public async Task<bool> IsCategoryIDAvailable(string id)
        {
            bool result = true;
            string sql = "SELECT Category_ID FROM Categories WHERE Category_ID = @Category_ID";
           
            var output = await Task.Run(() => db.LoadData<string, dynamic>(sql, new { Category_ID = id }, ConnectionString).Result.FirstOrDefault());

            if (!string.IsNullOrEmpty(output))
                result = false;
           

            return result;

        }



    }
}
