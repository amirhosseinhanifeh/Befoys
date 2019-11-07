using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.Entity.City;
using BEFOYS.DataLayer.Entity.Code;
using BEFOYS.DataLayer.Entity.Organization;
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
        public Guid Address_GUID { get; set; } = Guid.NewGuid();
        public string Address_Text { get; set; }
        public int? Address_CityID { get; set; }
        public bool Address_ISSetGPS { get; set; }
        public string Address_GPSLat { get; set; }
        public string Address_GPSLong { get; set; }
        public int Address_OrganizationID { get; set; }
        public int Address_TypeCodeID { get; set; }


        [ForeignKey("Address_CityID")]
        public Tbl_City City { get; set; }

        [ForeignKey("Address_OrganizationID")]
        public Tbl_Organization Organization { get; set; }

        [ForeignKey("Address_TypeCodeID")]
        public Tbl_Code Code { get; set; }

        public ICollection<Tbl_Phone> Phones { get; set; }

    }
}
