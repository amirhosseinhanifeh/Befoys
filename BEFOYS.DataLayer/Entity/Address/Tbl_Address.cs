using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.Entity.City;
using BEFOYS.DataLayer.Entity.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Entity.Address
{
    public class Tbl_Address
    {
        [Key]
        public int Address_ID { get; set; }
        public Guid Address_GUID { get; set; }
        public string Address_Text { get; set; }
        public int? Address_CityID { get; set; }
        public bool Address_ISSetGPS { get; set; }
        public string Address_GPSLat { get; set; }
        public string Address_GPSLong { get; set; }
        public int Address_LoginID { get; set; }
        public int Address_TypeCodeID { get; set; }


        [ForeignKey("Address_CityID")]
        public Tbl_City City { get; set; }

        [ForeignKey("Address_LoginID")]
        public Tbl_Login Login { get; set; }

        [ForeignKey("Address_TypeCodeID")]
        public Tbl_Code Code { get; set; }

        public ICollection<Tbl_Phone> Phones { get; set; }

    }
}
