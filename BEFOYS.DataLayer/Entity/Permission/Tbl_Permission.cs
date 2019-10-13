using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Permission
{
    public class Tbl_Permission
    {
        [Key]
        public int Permission_ID { get; set; }
        public Guid Permission_GUID { get; set; }
    }
}
