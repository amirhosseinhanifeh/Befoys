using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
    public class Tbl_SupplierReal
    {
        [Key]
        public int SR_ID { get; set; }
        public Guid SR_GUID { get; set; }
        public int SR_SupplierID { get; set; }

        [ForeignKey("SR_SupplierID")]
        public Tbl_Supplier Supplier { get; set; }
    }
}
