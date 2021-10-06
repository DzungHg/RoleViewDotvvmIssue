using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using AssetMan.UseCases.Interfaces;
using AssetMan.UseCases.DTO;
using AssetMan.UseCases.enums;


namespace AssetMan_WebApp.ViewModels.AssetMan
{
    public class AssetCreateViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IAssetCreateUseCase assetCreateUseCase;
        private readonly ICategoryViewAllUseCase categoryViewAllUseCase;
        private readonly ILocationViewAllUseCase locationViewAllUseCase;
        private readonly IContactViewAllUseCase contactViewAllUseCase;
        private readonly IFinanceCategoryViewAllUseCase financeCategoryViewAllUseCase;

        public AssetCreateViewModel(IAssetCreateUseCase assetCreateUseCase, ICategoryViewAllUseCase categoryViewAllUseCase,
                    ILocationViewAllUseCase locationViewAllUseCase, IContactViewAllUseCase contactViewAllUseCase,
                    IFinanceCategoryViewAllUseCase financeCategoryViewAllUseCaseBLL)
        {

            this.assetCreateUseCase = assetCreateUseCase;
            this.categoryViewAllUseCase = categoryViewAllUseCase;
            this.financeCategoryViewAllUseCase = financeCategoryViewAllUseCaseBLL;
            this.contactViewAllUseCase = contactViewAllUseCase;
            this.locationViewAllUseCase = locationViewAllUseCase;

        }

        [Bind(Direction.ClientToServer)]
        public List<CategoryDTO> CategoryList => this.categoryViewAllUseCase.Execute();
        public CategoryDTO SelectedCategory { get; set; }

        [Bind(Direction.ClientToServer)]
        public List<LocationDTO> LocationList => this.locationViewAllUseCase.Execute();
        public LocationDTO SelectedLocation { get; set; }

        [Bind(Direction.ClientToServer)]
        public List<CategoryInFinanceDTO> CategoryInFinanceList => this.financeCategoryViewAllUseCase.Execute();
        public CategoryInFinanceDTO SelectedCategoryInFinance { get; set; }

        [Bind(Direction.ClientToServer)]
        public List<ContactDTO> ContactList => this.contactViewAllUseCase.Execute();
        public ContactDTO SelectedContact { get; set; }


        public int SelectedCondition { get; set; } = (int)ConditionEn.BinhThuong;

        //
        public AssetDTO Asset { get; set; } = new AssetDTO()
        {
            Condition = ConditionEn.BinhThuong,
            AcquiredDate = DateTime.Today,
            RetiredDate = new DateTime(1945, 1, 1)
        };

        public string ActiveTabKey { get; set; } = "FirstTab";

        private void UpdateDataBeforeSaving()

        {
            if (this.SelectedCategoryInFinance != null)
                this.Asset.CategoryFinance_FK = this.SelectedCategoryInFinance.Category_ID;


            if (this.SelectedCategory != null)
                this.Asset.Category_FK = this.SelectedCategory.Category_ID;


            if (this.SelectedLocation != null)
                this.Asset.Location_FK = this.SelectedLocation.Location_SEQ;

            if (this.SelectedContact != null)
                this.Asset.Owner_FK = this.SelectedContact.ID;

            if (this.SelectedCondition > 0)
                this.Asset.Condition = (ConditionEn) this.SelectedCondition;

        }



        //Valid ation
        public string ValidationgMessagesText { get; set; }
        public List<string> ValidationgMessages { get; set; } = new();
        public bool IsDataValided()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.Asset.Item))
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu tên Tài sản");
            }

            if (this.SelectedCategory == null)
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu danh mục Tài sản");
            }

            if (this.SelectedCategoryInFinance == null)
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu danh mục kế toán Tài sản");
            }

            if (this.SelectedLocation == null)
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu Nơi để Tài sản");
            }

            if (this.SelectedContact == null)
            {
                result = false;
                this.ValidationgMessages.Add("Thiếu người phụ trách Tài sản");
            }

            return result;
        }
        public void ThemMoiTaiSan()
        {
            //
            UpdateDataBeforeSaving();
            //Check validation
            if (!this.IsDataValided())
            {
                this.ValidationgMessagesText = "Lỗi: ";
                foreach (var str in this.ValidationgMessages)
                {
                    this.ValidationgMessagesText += string.Format("{0} \n", str);
                }

                return;
            }

            this.ValidationgMessagesText = this.assetCreateUseCase.Execute(this.Asset);

            Context.RedirectToRoute("AssetList");
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void QuayLaiDanhSach()
        {
            Context.RedirectToRoute("AssetList");
        }
    }
}

