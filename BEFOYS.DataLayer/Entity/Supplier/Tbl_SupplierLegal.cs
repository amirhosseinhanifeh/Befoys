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
        public Guid SL_GUID { get; set; }
        public int SL_SupplierID { get; set; }

        [ForeignKey("SL_SupplierID")]
        public Tbl_Supplier Supplier { get; set; }
    }
}
