using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.BusinessPack.Controls;
using AssetMan.UseCases.LocationScreen;
using AssetMan.UseCases.DTO;

namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class LocationListViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IGetAllLocationsUseCase locationViewAllUseCase;

        
        public LocationListViewModel(IGetAllLocationsUseCase locationViewAllUseCase)
        {
            this.locationViewAllUseCase = locationViewAllUseCase;
           
        }

    
        public BusinessPackDataSet<LocationDTO> Locations { get; set; } = new BusinessPackDataSet<LocationDTO>
        {
            PagingOptions = {
                    PageSize = 20
                },
            SortingOptions =
                {
                    SortExpression = nameof(LocationDTO.Location_Name),
                    SortDescending = true
                }
        };
        public override Task PreRender()
        {
            if (Locations.IsRefreshRequired)
            {
               
                    Locations.Items = locationViewAllUseCase.Execute().Result;
               
            }

            return base.PreRender();
        }

      


        //Click sửa
        public void ViewLocation(int id)
        {
            Context.RedirectToRoute("FPManufactureDetail", new { Id = id });
        }
        public void EditFPManufacture(int id)
        {
            Context.RedirectToRoute("FPManufactureEdit", new { Id = id });
        }

        public void GenerateNewFPManufature(int id)
        {

        }

    }
}

