using BEFOYS.DataLayer.Entity.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.SubUser
{
    public class Tbl_SubUserRolePermission
    {
        [Key]
        public int SURP_ID { get; set; }
        public Guid SURP_GUID { get; set; } = Guid.NewGuid();
        public int SURP_SURID { get; set; }
        public int SURP_PermissionID { get; set; }

        [ForeignKey("SURP_SURID")]
        public Tbl_SubUserRole SubUserRole { get; set; }

        [ForeignKey("SURP_PermissionID")]
        public Tbl_Permission  Permission{ get; set; }
    }
}
