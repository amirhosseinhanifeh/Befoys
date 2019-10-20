using BEFOYS.DataLayer.Entity.Group;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Permission
{
    public class Tbl_GroupPermission
    {
        [Key]
        public int GP_ID { get; set; }
        public Guid GP_GUID { get; set; } = Guid.NewGuid();

        public int GP_PermissionID { get; set; }
        public int GP_GroupID { get; set; }

        [ForeignKey("GP_PermissionID")]
        public Tbl_Permission Permission { get; set; }

        [ForeignKey("GP_GroupID")]
        public Tbl_Group  Group { get; set; }
    }
}
