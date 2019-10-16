using BEFOYS.DataLayer.Entity.Province;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.City
{
    public class Tbl_City
    {
        [Key]
        public int City_ID { get; set; }
        public Guid City_GUID { get; set; }
        public string City_Name { get; set; }
        public string City_Display { get; set; }
        //public int Province_ID { get; set; }

        //[ForeignKey("Province_ID")]
        //public Tbl_Province Province{ get; set; }

    }
}
