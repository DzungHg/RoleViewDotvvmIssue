using Microsoft.Extensions.Configuration;
using System.IO;


namespace AssetMan.Plugins.Repository.SqliteDb.DataAccess
{
    public class DataConnects
    {
        public static string GetConnectionString(string connectionStringName = "AssetsData")
        {
            string output = "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json");
            var config = builder.Build();
            output = config.GetConnectionString(connectionStringName);
            return output;
        }
    }
}
