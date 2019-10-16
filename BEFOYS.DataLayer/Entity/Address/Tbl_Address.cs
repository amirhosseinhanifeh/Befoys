using BEFOYS.DataLayer.Entity.Province;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Address
{
    public class Tbl_Address
    {
        [Key]
        public int Address_ID { get; set; }
        public Guid Address_GUID { get; set; }
        public string Address_Text { get; set; }
        public int? Address_ProvinceID { get; set; }
        public bool Address_ISSetGPS { get; set; }
        public string Address_GPSLat { get; set; }
        public string Address_GPSLong { get; set; }


        [ForeignKey("Address_ProvinceID")]
        public Tbl_Province Province { get; set; }

        public ICollection<Tbl_Phone> Phones { get; set; }

    }
}
