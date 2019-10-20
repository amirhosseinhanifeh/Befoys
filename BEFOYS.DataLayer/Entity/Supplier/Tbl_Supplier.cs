using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.Entity.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
    public class Tbl_Supplier
    {
        [Key]
        public int Supplier_ID { get; set; }
        public Guid Supplier_GUID { get; set; } = Guid.NewGuid();
        public int? Supplier_TypeCodeID { get; set; }
        public int Supplier_LoginID { get; set; }
        public bool Supplier_Govahi { get; set; } = false;
        public string Supplier_Sheba { get; set; }
        public string Supplier_AccountName { get; set; }
        public string Supplier_AccountNumber { get; set; }
        public string Supplier_Brand { get; set; }
        public int? Supplier_MaxSupply { get; set; } = 0;
        public int? Supplier_CategoryID { get; set; }
        public int? Supplier_RegisterStateCodeID { get; set; }
        public string Supplier_Website { get; set; }


        [ForeignKey("Supplier_TypeCodeID")]
        public Tbl_Code Code { get; set; }

        [ForeignKey("Supplier_LoginID")]
        public Tbl_Login Login { get; set; }

        public ICollection<Tbl_SupplierLegal> SupplierLegals { get; set; }
        public ICollection<Tbl_SupplierReal> SupplierReals { get; set; }

    }
}
