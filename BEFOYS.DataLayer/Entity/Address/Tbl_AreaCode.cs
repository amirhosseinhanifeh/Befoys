using BEFOYS.DataLayer.Entity.City;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Address
{
   public class Tbl_AreaCode
    {
        [Key]
        public int AC_ID { get; set; }
        public Guid AC_GUID { get; set; }
        public int AC_CityID { get; set; }
        public string AC_Code { get; set; }

        [ForeignKey("AC_CityID")]
        public Tbl_City City { get; set; }

    }
}
