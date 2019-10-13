using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
    public class Tbl_SupplierReal
    {
        [Key]
        public int SR_ID { get; set; }
        public Guid SR_GUID { get; set; }
    }
}
