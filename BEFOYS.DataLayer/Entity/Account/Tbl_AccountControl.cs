
using BEFOYS.DataLayer.Entity.Panel;
using BEFOYS.DataLayer.Entity.Role;
using BEFOYS.DataLayer.Entity.SubUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Entity.Account
{
    public class Tbl_AccountControl
    {
        [Key]
        public int AC_ID { get; set; }
        public Guid AC_GUID { get; set; }
        public int AC_BaseRoleID { get; set; }
        public int? AC_BasePTID { get; set; }
        public bool AC_ISBasicAccount { get; set; }
        public bool? AC_IsSubUser { get; set; }
        public int? AC_LoginID { get; set; }
        public int? AC_SURID { get; set; }


        [ForeignKey("AC_LoginID")]
        public Tbl_Login Login { get; set; }

        [ForeignKey("AC_BasePTID")]
        public Tbl_PanelType PanelType { get; set; }

        [ForeignKey("AC_BaseRoleID")]
        public Tbl_BaseRole BaseRole { get; set; }

        [ForeignKey("AC_SURID")]
        public Tbl_SubUserRole SubUserRole { get; set; }
    }
}
