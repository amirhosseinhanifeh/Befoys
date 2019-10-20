using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Code
{
    public class Tbl_CodeGroup
    {
        [Key]
        public int CG_ID { get; set; }
        public Guid CG_GUID { get; set; } = Guid.NewGuid();
        public string CG_Name { get; set; }
        public string CG_Display { get; set; }


    }
}
