using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssetMan.UseCases.CategoryScreen;
using AssetMan.UseCases.DTO;

namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class CategoryEditViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IUpdateCategoryUseCase categoryUpdateUseCase;
        private readonly IGetCategoryByIdUseCase categoryGetByIdUseCase;

        public CategoryEditViewModel(IUpdateCategoryUseCase categoryUpdateUseCase, IGetCategoryByIdUseCase categoryGetByIdUseCase)
        {

            this.categoryUpdateUseCase = categoryUpdateUseCase;
            this.categoryGetByIdUseCase = categoryGetByIdUseCase;

        }

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                string id = "";
                id = Context.Parameters["Id"].ToString();

                this.Category = categoryGetByIdUseCase.Execute(id).Result;


                //int id = Convert.ToInt32(Context.Parameters["id"]);

                //
            }

            return base.PreRender();
        }


        //
        public CategoryDTO Category { get; set; }

        //Valid ation
        public string ValidationMessagesText { get; set; }
        public List<string> ValidationgMessages { get; set; } = new();
        public bool IsDataValided()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.Category.Category_Name))
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu tên Tài sản");
            }



            return result;
        }





        public void EditCategory()
        {
            //Check validation
            if (!this.IsDataValided())
            {
                this.ValidationMessagesText = "Lỗi: ";
                foreach (var str in this.ValidationgMessages)
                {
                    this.ValidationMessagesText += string.Format("{0} \n", str);
                }

                return;
            }
            //Psss
            this.categoryUpdateUseCase.Execute(this.Category);

            Context.RedirectToRoutePermanent("CategoryList", replaceInHistory: true);
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void Huy()
        {
            Context.RedirectToRoutePermanent("CategoryList", replaceInHistory: true);
        }
      
    }
}

