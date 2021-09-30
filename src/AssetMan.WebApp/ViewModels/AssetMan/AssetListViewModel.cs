using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.BusinessPack.Controls;
using AssetMan.UseCases.Interfaces;
using AssetMan.UseCases.DTO;

namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class AssetListViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IAssetViewAllUseCase assetViewAllUseCase;
        private readonly IAssetsByCategoryUseCase assetsByCategoryUseCase;
        private readonly ICategoryViewAllUseCase categoryViewAllUseCase;
       
        public AssetListViewModel(IAssetViewAllUseCase assetViewAllUseCase, ICategoryViewAllUseCase categoryViewAllUseCase,
            IAssetsByCategoryUseCase assetsByCategoryUseCase)
        {
            this.assetViewAllUseCase = assetViewAllUseCase;
            this.categoryViewAllUseCase = categoryViewAllUseCase;
            this.assetsByCategoryUseCase = assetsByCategoryUseCase;
        }

    
        public BusinessPackDataSet<AssetViewDTO> Assets { get; set; } = new BusinessPackDataSet<AssetViewDTO>
        {
            PagingOptions = {
                    PageSize = 20
                },
            SortingOptions =
                {
                    SortExpression = nameof(AssetDTO.Item),
                    SortDescending = true
                }
        };
        public override Task PreRender()
        {
            if (Assets.IsRefreshRequired)
            {
                LoadAssests();
            }

            return base.PreRender();
        }
        private void LoadAssests()
        {
            IQueryable<AssetViewDTO> asListQue;
            if (this.SelectedCategory != null)
            {
                asListQue = assetsByCategoryUseCase.Execute(this.SelectedCategory.Category_ID).AsQueryable();
                this.Assets.LoadFromQueryable(asListQue);
            }
            else
            {
                asListQue = assetViewAllUseCase.Execute().AsQueryable();
                this.Assets.LoadFromQueryable(asListQue);
            }
        }
        public void CategoriesComboChanged()
        {
            LoadAssests();
        }

        [Bind(Direction.ClientToServer)]
        public List<CategoryDTO> CateogryList => this.categoryViewAllUseCase.Execute();
        public CategoryDTO SelectedCategory { get; set; }

        //Click sửa
        public void FPManufactureDetail(int id)
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

