using AssetMan.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetMan.UseCases.DTO;

namespace AssetMan.UseCases.AssetScreen
{
    public interface IGetAllAssetViewsUseCase
    {
        Task<List<AssetViewDTO>> Execute();
    }
}
