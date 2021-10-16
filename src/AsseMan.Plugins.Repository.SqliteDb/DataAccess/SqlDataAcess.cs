using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AssetMan.Plugins.Repository.SqliteDb.DataAccess
{
    public class SqlDataAcess
    {
        public async Task<List<T>> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sqlStatement, parameters);
                return rows.ToList();
            }
        }
        public async Task SavingData<T>(string sqlStatement, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                await connection.ExecuteAsync(sqlStatement, parameters);
            }
        } 

    }
}
