using BEFOYS.DataLayer.Entity.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.SubUser
{
    public class Tbl_SubUserRole
    {
        [Key]
        public int SUR_ID { get; set; }
        public Guid SUR_GUID { get; set; }
        public int SUR_LoginID { get; set; }
        public string SUR_Name { get; set; }
        public string SUR_Display { get; set; }

        [ForeignKey("SUR_LoginID")]
        public Tbl_Login  Login { get; set; }
    }
}
