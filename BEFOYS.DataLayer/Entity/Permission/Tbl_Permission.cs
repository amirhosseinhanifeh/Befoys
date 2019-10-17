using BEFOYS.DataLayer.Entity.Panel;
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
        public int? Permission_CodeID { get; set; }
        public string Permission_Name { get; set; }
        public string Permission_Display { get; set; }
        public bool Permission_ISFree { get; set; }

        public ICollection<Tbl_PanelTypePermission> PanelTypePermissions { get; set; }

    }
}
