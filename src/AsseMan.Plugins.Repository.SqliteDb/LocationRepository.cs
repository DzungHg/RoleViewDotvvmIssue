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
    public class LocationRepository : ILocationRepository
    {

        private SqlDataAcess db = new SqlDataAcess();

        private readonly string ConnectionString = DataConnects.GetConnectionString();

        #region  Listing
        //Listing
        public async Task<List<Location>> GetAllLocations()
        {
            string sql = "SELECT * FROM Locations";
            return await db.LoadData<Location, dynamic>(sql, new { }, ConnectionString);
        }

        //Get Location
        public async Task<Location> GetLocationById(int sEQ)
        {
            string sql = "SELECT * FROM Locations WHERE Location_SEQ = @Location_SEQ";
            Location output;
            output = await Task.Run(()=> db.LoadData<Location, dynamic>(sql, new { Location_SEQ = sEQ }, ConnectionString).Result.FirstOrDefault());

            if (output == null)
            {
                //Do something

                return null;
            }

            return output;

        }
        //write 
        public async Task CreateLocation(Location location)
        {
            string sql = "INSERT INTO Locations (Location_Name, Description)"
                + " VALUES (@Location_Name,  @Description);";

            await db.SavingData(sql, new
            {
                location.Location_Name,
                location.Description

            }, ConnectionString);


        }
        //update Location 
        public async Task UpdateLocation(Location asset)
        {
            string sql = "UPDATE Locations SET Location_Name = @Location_Name,  Description = @Description"
                + " WHERE Location_SEQ = @Location_SEQ ";

            await db.SavingData(sql, asset, ConnectionString);

        }

        //remove Location 
        public async Task RemoveLocation(int sEQ)
        {
            string sql = "DELETE from Locations WHERE Location_SEQ = @Location_SEQ;";

            await db.SavingData(sql, new { Location_SEQ = sEQ }, ConnectionString);

        }
        #endregion



    }
}
