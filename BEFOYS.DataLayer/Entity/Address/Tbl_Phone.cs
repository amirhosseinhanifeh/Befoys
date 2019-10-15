using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Address
{
    public class Tbl_Phone
    {
        [Key]
        public int Phone_ID { get; set; }
        public Guid Phone_GUID { get; set; }
        public int Phone_CodeID { get; set; }
        public int Phone_AreaCode { get; set; }
        public string Phone_Number { get; set; }
        public int Phone_AddressID { get; set; }

        [ForeignKey("Phone_AddressID")]
        public Tbl_Address Address { get; set; } 
    }
}
