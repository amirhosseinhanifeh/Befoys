using BEFOYS.DataLayer.Entity.Address;
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
        public Guid City_GUID { get; set; } = Guid.NewGuid();
        public string City_Name { get; set; }
        public string City_Display { get; set; }
        public int City_ProvinceID { get; set; }

        [ForeignKey("City_ProvinceID")]
        public Tbl_Province Province { get; set; }

        public ICollection<Tbl_Address> Addresses { get; set; }

    }
}
