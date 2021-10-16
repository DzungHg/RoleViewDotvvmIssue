using AssetMan.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMan.UseCases.RepositoryPlugins
{
    public interface IAssetRepository
    {
       
        Task<List<Asset>> GetAllAssets();
        Task<List<AssetView>> GetAllAssetViews();
        Task<List<AssetView>> GetAllAssetViewsByCategory(string iD);
        Task<string> CreateAsset(Asset asset);
        Task<string> UpdateAsset(Asset asset);

        Task<Asset> GetAssetById(int id);
        Task RemoveAsset(int id);
        Task<bool> IsConTrolCodeAvailable(string id);


    }
}
