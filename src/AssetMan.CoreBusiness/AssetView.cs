using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AssetMan.CoreBusiness
{
    public class AssetView
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public string ControlCode { get; set; }
        public int Condition { get; set; }
        public DateTime AcquiredDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal CurrentValue { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public DateTime RetiredDate { get; set; }
        public string Condition_Name { get; set; }
        public string Location_Name { get; set; }
        public string Owner_Name { get; set; }
        public string Category_Name { get; set; }
        public string CategoryInFinance_Name { get; set; }
    }
}
