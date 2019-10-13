using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
    public class Tbl_Supplier
    {
        [Key]
        public int Supplier_ID { get; set; }
        public Guid Supplier_GUID { get; set; }

    }
}
