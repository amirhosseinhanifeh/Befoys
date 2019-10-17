using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
   public class Tbl_SupplierLegalAgent
    {
        [Key]
        public int SLA_ID { get; set; }
        public Guid SLA_GUID { get; set; }
        public string SLA_Name { get; set; }
        public string SLA_Family { get; set; }
        public string SLA_Mobile { get; set; }
        public int SLA_TypeCodeID { get; set; }
        public string SLA_NationalCode { get; set; }
        public string SLA_ShenasnameID { get; set; }
        public int SLA_GenderCodeID { get; set; }
        public int SLA_SLID { get; set; }

        [ForeignKey("SLA_SLID")]
        public Tbl_SupplierLegal SupplierLegal { get; set; }
    }
}
