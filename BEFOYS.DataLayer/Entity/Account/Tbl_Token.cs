using BEFOYS.DataLayer.Entity.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Account
{
    public class Tbl_Token
    {
        [Key]
        public int Token_ID { get; set; }
        public Guid Token_GUID { get; set; } = Guid.NewGuid();
        public int Token_TypeCodeID { get; set; }
        public DateTime Token_Start { get; set; }
        public DateTime Token_EXP { get; set; }
        public string Token_Hush { get; set; }
        public int Token_LoginID { get; set; }

        [ForeignKey("Token_LoginID")]
        public Tbl_Login Login { get; set; }

        [ForeignKey("Token_TypeCodeID")]
        public Tbl_Code Code { get; set; }
    }
}
