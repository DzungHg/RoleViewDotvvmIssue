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
    public class AssetEditlViewModel : AssetMan_WebApp.ViewModels.MasterPageViewModel
    {
        private readonly IAssetUpdateUseCase assetUpdateUseCase;
        private readonly IAssetGetByIdUseCase assetGetByIdUseCase;

        private readonly ICategoryViewAllUseCase categoryViewAllUseCase;
        private readonly ICategoryGetByIdUseCase categoryGetByIdUseCase;

        private readonly ILocationViewAllUseCase locationViewAllUseCase;
        private readonly ILocationGetByIdUseCase locationGetByIdUseCase;

        private readonly IContactViewAllUseCase contactViewAllUseCase;
        private readonly IContactGetByIdUseCase contactGetByIdUseCase;

        private readonly IFinanceCategoryViewAllUseCase financeCategoryViewAllUseCase;
        private readonly IFinanceCategoryGetByIdUseCase financeCategoryGetByIdUseCase;

        public AssetEditlViewModel (IAssetUpdateUseCase assetUpdateUseCase, ICategoryViewAllUseCase categoryViewAllUseCase, ICategoryGetByIdUseCase categoryGetByIdUseCase,
            ILocationViewAllUseCase locationViewAllUseCase, ILocationGetByIdUseCase locationGetByIdUseCase,
            IFinanceCategoryViewAllUseCase financeCategoryViewAllUseCaseBLL, IFinanceCategoryGetByIdUseCase financeCategoryGetByIdUseCase,
                    IContactViewAllUseCase contactViewAllUseCase, IContactGetByIdUseCase contactGetByIdUseCase,
                    IAssetGetByIdUseCase assetGetByIdUseCase)
        {

            this.assetUpdateUseCase = assetUpdateUseCase;
            this.categoryViewAllUseCase = categoryViewAllUseCase;
            this.financeCategoryViewAllUseCase = financeCategoryViewAllUseCaseBLL;
            this.contactViewAllUseCase = contactViewAllUseCase;
            this.locationViewAllUseCase = locationViewAllUseCase;
            //
            this.categoryGetByIdUseCase = categoryGetByIdUseCase;
            this.locationGetByIdUseCase = locationGetByIdUseCase;
            this.contactGetByIdUseCase = contactGetByIdUseCase;
            this.financeCategoryGetByIdUseCase = financeCategoryGetByIdUseCase;

            this.assetGetByIdUseCase = assetGetByIdUseCase;

        }

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                int id = 0;
                if (int.TryParse(Context.Parameters["Id"].ToString(), out id))
                {
                    this.OriginalAsset = assetGetByIdUseCase.Execute(id);
                    //Cập nhật qua Asset để hiệu đính:
                    this.Asset = new();
                    UpdateAssetFromOriginal();
                }
                //Update một số combo
                if (!string.IsNullOrEmpty(this.Asset.CategoryFinance_FK))
                    this.SelectedCategoryInFinance = this.financeCategoryGetByIdUseCase.Execute(this.Asset.CategoryFinance_FK);

                if (!string.IsNullOrEmpty(this.Asset.Category_FK))
                    this.SelectedCategory = this.categoryGetByIdUseCase.Execute(this.Asset.Category_FK);

                if (this.Asset.Location_FK >0)
                {
                    this.SelectedLocation = this.locationGetByIdUseCase.Execute(this.Asset.Location_FK);
                }
                if (this.Asset.Owner_FK > 0)
                {
                    this.SelectedContact = this.contactGetByIdUseCase.Execute(this.Asset.Owner_FK);
                }
                
                if (this.Asset.Condition > 0)
                {
                    this.SelectedCondition = (int)this.Asset.Condition;
                }
                //Bật tắt
                this.SuaButtonEnabled = true;
                this.GhiLaiButtonEnabled = false;
                this.KhongGhiButtonEnabled = false;
            }
            //int id = Convert.ToInt32(Context.Parameters["id"]);

            //


            return base.PreRender();
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
        public AssetDTO OriginalAsset { get; set; }
        public AssetDTO Asset { get; set; }

        private void UpdateAssetFromOriginal()
        {
            if (this.Asset == null)
                return;
            //
            this.Asset.ID = this.OriginalAsset.ID;
            this.Asset.Item = this.OriginalAsset.Item;
            this.Asset.Description = this.OriginalAsset.Description;
            this.Asset.Category_FK = this.OriginalAsset.Category_FK;
            this.Asset.CategoryFinance_FK = this.OriginalAsset.CategoryFinance_FK;
            this.Asset.Condition = this.OriginalAsset.Condition;
            this.Asset.AcquiredDate = this.OriginalAsset.AcquiredDate;
            this.Asset.CurrentValue = this.OriginalAsset.CurrentValue;
            this.Asset.Location_FK = this.OriginalAsset.Location_FK;
            this.Asset.Manufacturer = this.OriginalAsset.Manufacturer;
            this.Asset.Model = this.OriginalAsset.Model;
            this.Asset.Comments = this.OriginalAsset.Comments;
            this.Asset.Owner_FK = this.OriginalAsset.Owner_FK;
            this.Asset.Attachments = this.OriginalAsset.Attachments;
            this.Asset.RetiredDate = this.OriginalAsset.RetiredDate;
        }
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
                this.Asset.Condition = (ConditionEn)this.SelectedCondition;


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
        public bool SuaButtonEnabled { get; set; }
        public bool GhiLaiButtonEnabled { get; set; }
        public bool KhongGhiButtonEnabled { get; set; }

        public void Sua()
        {
            this.SuaButtonEnabled = false;
            this.GhiLaiButtonEnabled = true;
            this.KhongGhiButtonEnabled = true;
    }
        public void KhongGhi()
        {
            //Trả lại nguyên trạng 
            UpdateAssetFromOriginal();
            this.SuaButtonEnabled = true;
            this.GhiLaiButtonEnabled = false;
            this.KhongGhiButtonEnabled = false;
        }
        public void GhiLaiTaiSan()
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

            this.ValidationgMessagesText = this.assetUpdateUseCase.Execute(this.Asset);

            Context.RedirectToRoute("AssetDetail", new { Id = this.Asset.ID });
            // Chưa thực hiện
            /* 
            this.paperStockPriceBLL.RemovePaperStockPrice(this.PaperStockPrice.PaperStock_SEQ);
            //redirect
            Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
            */
        }
        public void Huy()
        {
            Context.RedirectToRoute("AssetDetail", new { Id = this.Asset.ID });
        }

        public void QuayLaiDanhSach()
        {
            Context.RedirectToRoute("CategoryList", replaceInHistory: true);
        }

    }
}

