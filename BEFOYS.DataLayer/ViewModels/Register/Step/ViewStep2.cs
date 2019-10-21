using BEFOYS.DataLayer.Entity.Supplier;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.Step
{
    public class ViewStep2
    {
        public bool Supplier_Govahi { get; set; } = false;
        public string Supplier_Sheba { get; set; }
        public string Supplier_AccountName { get; set; }
        public string Supplier_AccountNumber { get; set; }
        public string Supplier_Brand { get; set; }
        public int? Supplier_MaxSupply { get; set; } = 0;
        public int? Supplier_CategoryID { get; set; }
        public ViewStep2(Tbl_Supplier model)
        {
            Supplier_AccountName = model.Supplier_AccountName;
            Supplier_AccountNumber = model.Supplier_AccountNumber;
            Supplier_Brand = model.Supplier_Brand;
            Supplier_Govahi = model.Supplier_Govahi;
            Supplier_MaxSupply = model.Supplier_MaxSupply;
            Supplier_Sheba = model.Supplier_Sheba;
            Supplier_CategoryID = model.Supplier_CategoryID;
        }
    }
}
