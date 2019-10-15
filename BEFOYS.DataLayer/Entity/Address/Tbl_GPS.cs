using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Address
{
    public class Tbl_GPS
    {
        [Key]
        public int GPS_ID { get; set; }
        public Guid GPS_GUID { get; set; }
        public string GPS_Lat { get; set; }
        public string GPS_Lang { get; set; }
    }
}
