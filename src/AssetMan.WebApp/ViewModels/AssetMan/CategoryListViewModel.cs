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
    public class CategoryListViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly ICategoryViewAllUseCase categoryViewAllUseCase;

        
        public CategoryListViewModel(ICategoryViewAllUseCase categoryViewAllUseCase)
        {
            this.categoryViewAllUseCase = categoryViewAllUseCase;
           
        }

    
        public BusinessPackDataSet<CategoryDTO> Categories { get; set; } = new BusinessPackDataSet<CategoryDTO>
        {
            PagingOptions = {
                    PageSize = 20
                },
            SortingOptions =
                {
                    SortExpression = nameof(CategoryDTO.Category_Name),
                    SortDescending = true
                }
        };
        public override Task PreRender()
        {
            if (Categories.IsRefreshRequired)
            {
               
                    Categories.Items = categoryViewAllUseCase.Execute();
               
            }

            return base.PreRender();
        }

      


        //Click sửa
        public void ViewCategory(int id)
        {
            //Context.RedirectToRoute("FPManufactureDetail", new { Id = id });
        }
        public void EditCategory(int id)
        {
            //Context.RedirectToRoute("FPManufactureEdit", new { Id = id });
        }

        }
}

