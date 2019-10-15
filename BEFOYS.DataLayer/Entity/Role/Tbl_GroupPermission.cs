using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Role
{
    public class Tbl_GroupPermission
    {
        [Key]
        public int GP_ID { get; set; }
        public Guid GP_GUID { get; set; }
        public int GP_PermissionID { get; set; }
        public int GP_GroupID { get; set; }

    }
}
