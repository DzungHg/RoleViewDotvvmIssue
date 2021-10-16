using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using System.ComponentModel.DataAnnotations;
using AssetMan.UseCases.CategoryScreen;
using AssetMan.UseCases.DTO;


namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class CategoryCreateViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly ICreateCategoryUseCase categoryCreateUseCase;
        private readonly IIsCategoryIdAvailableUseCase categoryIsIdAvailableUseCase;

        public CategoryCreateViewModel(ICreateCategoryUseCase categoryCreateUseCase, IIsCategoryIdAvailableUseCase categoryIsIdAvailableUseCase)
        {

            this.categoryCreateUseCase = categoryCreateUseCase;
            this.categoryIsIdAvailableUseCase = categoryIsIdAvailableUseCase;

        }

        //
        public CategoryDTO Category { get; set; }

        [Required]
        public string Category_ID { get; set; }

        [Required]
        public string Category_Name { get; set; }

        //Valid ation
        public string ValidationMessagesText { get; set; }
        public List<string> ValidationMessages { get; set; } = new();
        public bool IsDataValided()
        {
            bool result = true;
            if (string.IsNullOrEmpty(this.Category.Category_ID))
            {
                result = false;
                this.ValidationMessages.Add("Mã danh mục thiếu");
            }
            else if (!this.categoryIsIdAvailableUseCase.Execute(this.Category.Category_ID).Result)
            {
                result = false;
                this.ValidationMessages.Add("Mã danh mục đã tồn tại");
            }    

            if (string.IsNullOrEmpty(this.Category.Category_Name))
            {
                result = false;
                this.ValidationMessages.Add("Thiếu tên Danh mục");
            }

          

            return result;
        }
        public void ThemMoiCategory()
        {
            this.Category = new CategoryDTO
            {
                Category_ID = this.Category_ID.ToUpper(),
                Category_Name = this.Category_Name
            };

            //Check validation
            if (!this.IsDataValided())
            {
                this.ValidationMessagesText = "Lỗi: ";
                foreach (var str in this.ValidationMessages)
                {
                    this.ValidationMessagesText += string.Format("{0} \n", str);
                }

                return;
            }

            this.categoryCreateUseCase.Execute(this.Category);

            Context.RedirectToRoute("CategoryList");
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void QuayLaiDanhSach()
        {
            Context.RedirectToRoute("CategoryList");
        }
    }
}

