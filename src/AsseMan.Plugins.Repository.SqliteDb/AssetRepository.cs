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
    public class AssetRepository : IAssetRepository
    {//private readonly string _connectionString = DataConnects.GetConnectionString();

        private readonly SqlDataAcess db = new SqlDataAcess();

        private readonly string ConnectionString = DataConnects.GetConnectionString();

        #region Listing 
        //Listing
        public async Task<List<AssetView>> GetAllAssetViews()
        {
          
            string sql = @"SELECT
                                ast.ID,
                                ast.Item,
                                ast.ControlCode,                                        
                                ast.Condition,
	                            ast.AcquiredDate,
                                ast.PurchasePrice,
                                ast.Manufacturer,
                                ast.Model,                      
                                ast.RetiredDate,
                                ast.Description,
	                            cat.Category_Name as [Category_Name], 
	                            fcat.Category_Name as [CategoryInFinance_Name], 
	                            ct.FirstName as [Owner_Name],
                                lc.Location_Name as [Location_Name]
                            FROM Assets as ast
                            JOIN Categories as cat on ast.Category_FK = cat.Category_ID
                            JOIN CategoriesInFinance as fcat on ast.CategoryFinance_FK = fcat.Category_ID
                            JOIN Contacts as ct on ast.Owner_FK = ct.ID
                            JOIN Locations as lc on ast.Location_FK = lc.Location_SEQ;";

            return await db.LoadData<AssetView, dynamic>(sql, new { }, ConnectionString);
        }
        public async Task<List<Asset>> GetAllAssets()
        {
           string sql = "SELECT * FROM Assets";
        
            return await db.LoadData<Asset, dynamic>(sql, new { }, ConnectionString);
        }
        public async Task<List<AssetView>> GetAllAssetViewsByCategory(string iD)
        {
            //string sql = "SELECT * FROM Assets  WHERE Category_FK = @Category_FK ";
            string sql = @"SELECT
                                ast.ID,
                                ast.Item,
                                ast.ControlCode,                                             
                                ast.Condition,
	                            ast.AcquiredDate,
                                ast.PurchasePrice,                      
                                ast.Manufacturer,
                                ast.Model,                 
                                ast.RetiredDate,
                                ast.Description,
	                            cat.Category_Name as [Category_Name], 
	                            fcat.Category_Name as [CategoryInFinance_Name], 
	                            ct.FirstName as [Owner_Name],
                                lc.Location_Name as [Location_Name]
                            FROM Assets as ast
                            JOIN Categories as cat on ast.Category_FK = cat.Category_ID
                            JOIN CategoriesInFinance as fcat on ast.CategoryFinance_FK = fcat.Category_ID
                            JOIN Contacts as ct on ast.Owner_FK = ct.ID
                            JOIN Locations as lc on ast.Location_FK = lc.Location_SEQ
                            WHERE Category_FK = @Category_FK;";
            return await db.LoadData<AssetView, dynamic>(sql, new { Category_FK = iD }, ConnectionString);
        }

        //Get Asset
        public async Task<Asset> GetAssetById(int id)
        {
            string sql = "SELECT * FROM Assets WHERE ID = @ID";
            
            return await Task.Run(() => db.LoadData<Asset, dynamic>(sql, new { ID = id }, ConnectionString).Result.SingleOrDefault());
           

        }
        //write 
        public async Task<string> CreateAsset(Asset asset)
        {
            string result = "";

            string sql = "INSERT INTO Assets (Item, ControlCode, Description, Category_FK, CategoryFinance_FK, Condition, AcquiredDate, PurchasePrice,"
                + " CurrentValue, Location_FK, Manufacturer, Model, Comments, Owner_FK, Attachments, RetiredDate)"
                + " VALUES (@Item, @ControlCode, @Description, @Category_FK, @CategoryFinance_FK, @Condition, @AcquiredDate, @PurchasePrice,"
                + " @CurrentValue, @Location_FK, @Manufacturer, @Model, @Comments, @Owner_FK, @Attachments, @RetiredDate);";
            try
            {


                await db.SavingData(sql, new
                {

                    asset.Item,
                    asset.ControlCode,
                    asset.Description,
                    asset.Category_FK,
                    asset.CategoryFinance_FK,
                    asset.Condition,
                    asset.AcquiredDate,
                    asset.PurchasePrice,
                    asset.CurrentValue,
                    asset.Location_FK,
                    asset.Manufacturer,
                    asset.Model,
                    asset.Comments,
                    asset.Owner_FK,
                    asset.Attachments,
                    asset.RetiredDate
                }, ConnectionString);
            }
            catch (Exception e)
            {
                result = $"Lỗi; {e.Message}";
            }

            return  result;
        }
        //update Asset 
        public async Task<string> UpdateAsset(Asset asset)
        {
            var result = "Hoàn thành!";

            string sql = "UPDATE Assets SET Item = @Item, ControlCode = @ControlCode, Description = @Description, Category_FK = @Category_FK,"
                + " CategoryFinance_FK = @CategoryFinance_FK, Condition = @Condition, AcquiredDate = @AcquiredDate,"
                + " PurchasePrice = @PurchasePrice, CurrentValue = @CurrentValue, Location_FK = @Location_FK, Manufacturer = @Manufacturer, Model = @Model,"
                + " Comments = @Comments, Owner_FK = @Owner_FK, Attachments = @Attachments, RetiredDate = @RetiredDate"
                + " WHERE ID = @ID ";
            try
            {
                await db.SavingData(sql, asset, ConnectionString);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return result;

        }

        //remove Asset 
        public async Task  RemoveAsset(int id)
        {
            string sql = "DELETE from Assets WHERE ID = @ID;";

            await db.SavingData(sql, new { ID = id }, ConnectionString);

        }
        #endregion
        //Hỗ trợ

        public async Task<bool> IsConTrolCodeAvailable(string id)
        {
            bool result = true;
            string sql = "SELECT ControlCode FROM Assets WHERE ControlCode = @ControlCode";

            var output = await Task.Run(() => db.LoadData<string, dynamic>(sql, new { ControlCode = id }, ConnectionString).Result.FirstOrDefault());

            if (!string.IsNullOrEmpty(output))
                result = false;


            return result;

        }


    }
}
