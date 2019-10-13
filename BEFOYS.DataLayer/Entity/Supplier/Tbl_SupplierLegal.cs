using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
    public class Tbl_SupplierLegal
    {
        [Key]
        public int SL_ID { get; set; }
        public Guid SL_GUID { get; set; }
    }
}
