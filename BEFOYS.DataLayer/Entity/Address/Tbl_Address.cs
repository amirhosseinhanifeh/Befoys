using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Address
{
    public class Tbl_Address
    {
        [Key]
        public int Address_ID { get; set; }
        public Guid Address_GUID { get; set; }
        public string Address_Text { get; set; }
        public int Address_GPSID { get; set; }

        public ICollection<Tbl_Phone> Phones { get; set; }

    }
}
