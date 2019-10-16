using BEFOYS.DataLayer.Entity.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Customer
{
    public class Tbl_Customer
    {
        [Key]
        public int Customr_ID { get; set; }
        public Guid Customer_GUID { get; set; }
        public int Customer_LoginID { get; set; }

        [ForeignKey("Customer_LoginID")]
        public Tbl_Login Login{ get; set; }

    }
}
