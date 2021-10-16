using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetMan.UseCases.enums;

namespace AssetMan.UseCases.DTO
{
    public class AssetDTO
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public string ControlCode { get; set; }
        public string Description { get; set; }
        public string Category_FK { get; set; }
        public string CategoryFinance_FK { get; set; }
        public ConditionEn Condition { get; set; }
        public DateTime AcquiredDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal CurrentValue { get; set; }
        public int Location_FK { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Comments { get; set; }
        public int Owner_FK { get; set; }
        public string Attachments { get; set; }
        public DateTime RetiredDate { get; set; }
        //Thêm nhưng không lưu
        public string Condition_Name { get; set; }
        public string Location_Name { get; set; }
        public string Owner_Name { get; set; }
        public string Category_Name { get; set; }
        public string CategoryInFinance_Name { get; set; }
    }
}
