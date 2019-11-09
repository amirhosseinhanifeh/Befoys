using BEFOYS.DataLayer.Entity.City;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Province
{
    public class Tbl_Province
    {
        [Key]
        public int Province_ID { get; set; }
        public Guid Province_GUID { get; set; } = Guid.NewGuid();
        public string Province_Name { get; set; }
        public string Province_Display { get; set; }
        public int Province_CityID { get; set; }

        //[ForeignKey("Province_CityID")]
        //public Tbl_City City { get; set; }

    }
}
