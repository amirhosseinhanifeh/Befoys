using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Province
{
    public class Tbl_Province
    {
        [Key]
        public int Province_ID { get; set; }
        public Guid Province_GUID { get; set; }
    }
}
