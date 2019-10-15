using BEFOYS.DataLayer.Entity.Permission;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Entity.Panel
{
    public class Tbl_PanelTypePermission
    {
        [Key]
        public int PTP_ID { get; set; }
        public Guid PTP_GUID { get; set; }
        public int PTP_PTID { get; set; }
        public int PTP_PermissionID { get; set; }

        [ForeignKey("PTP_PTID")]
        public Tbl_PanelType PanelType { get; set; }

        [ForeignKey("PTP_PermissionID")]
        public Tbl_Permission Permission { get; set; }
    }
}
