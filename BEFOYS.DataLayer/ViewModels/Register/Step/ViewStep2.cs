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
    }
}
