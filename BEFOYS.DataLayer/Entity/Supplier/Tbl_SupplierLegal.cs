using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
    public class Tbl_SupplierLegal
    {
        [Key]
        public int SL_ID { get; set; }
        public Guid SL_GUID { get; set; } = Guid.NewGuid();
        public int SL_SupplierID { get; set; }
        public string SL_CompanyName { get; set; }
        public int? SL_CompanyTypeCodeID { get; set; }
        public string SL_SabtNumber { get; set; }
        public string SL_NationalCode { get; set; }
        public string SL_EconomicCode { get; set; }
        public bool? SL_HasAgent { get; set; }


        [ForeignKey("SL_SupplierID")]
        public Tbl_Supplier Supplier { get; set; }
    }
}
