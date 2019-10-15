
using BEFOYS.DataLayer.Entity.Panel;
using BEFOYS.DataLayer.Entity.Role;
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
        public int AC_BasePTID { get; set; }
        public bool AC_ISBasicAccount { get; set; }

        [ForeignKey("AC_BasePTID")]
        public Tbl_PanelType PanelType { get; set; }

        [ForeignKey("AC_BaseRoleID")]
        public Tbl_BaseRole BaseRole { get; set; }

        public ICollection<Tbl_Login> Logins { get; set; }
    }
}
