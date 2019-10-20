using BEFOYS.DataLayer.Entity.Province;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Part
{
    public class Tbl_Part
    {
        [Key]
        public int Part_ID { get; set; }
        public Guid Part_GUID { get; set; } = Guid.NewGuid();
        public string Part_Name { get; set; }
        public string Part_Display { get; set; }
        public int Part_ProvinceID { get; set; }

        [ForeignKey("Part_ProvinceID")]
        public Tbl_Province Province { get; set; }
    }
}
