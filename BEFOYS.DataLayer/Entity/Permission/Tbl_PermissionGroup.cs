using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Permission
{
    public class Tbl_PermissionGroup
    {
        [Key]
        public int PG_ID { get; set; }
        public Guid PG_GUID { get; set; }
    }
}
