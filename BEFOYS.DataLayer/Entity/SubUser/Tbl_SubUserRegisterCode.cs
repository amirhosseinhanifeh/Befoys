using BEFOYS.DataLayer.Entity.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.SubUser
{
    public class Tbl_SubUserRegisterCode
    {
        [Key]
        public int SURC_ID { get; set; }
        public Guid SURC_GUID { get; set; } = Guid.NewGuid();
        public int SURC_LoginID { get; set; }
        public int SURC_SURID { get; set; }
        public string SURC_Code { get; set; }
        public DateTime SURC_Start { get; set; } = DateTime.Now;
        public bool SURC_ISExpired { get; set; } = false;

        [ForeignKey("SURC_LoginID")]
        public Tbl_Login Login { get; set; }

        [ForeignKey("SURC_SURID")]
        public Tbl_SubUserRole SubUserRole { get; set; }

    }
}
