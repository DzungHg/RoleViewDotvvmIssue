using AssetMan.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMan.UseCases.RepositoryPlugins
{
    public interface ILocationRepository
    {
       
        Task<List<Location>> GetAllLocations();

        Task CreateLocation(Location location);
        Task UpdateLocation(Location location);

        Task<Location> GetLocationById(int id);
        Task RemoveLocation(int id);
      
    }
}
