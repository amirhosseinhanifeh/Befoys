using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_PanelTypePermission")]
    public partial class TblPanelTypePermission
    {
        public TblPanelTypePermission()
        {
            TblOrganizationPanelType = new HashSet<TblOrganizationPanelType>();
        }

        [Key]
        [Column("PTP_ID")]
        public int PtpId { get; set; }
        [Column("PTP_GUID")]
        public Guid PtpGuid { get; set; }
        [Column("PTP_PTID")]
        public int PtpPtid { get; set; }
        [Column("PTP_PermissionID")]
        public int PtpPermissionId { get; set; }

        [ForeignKey(nameof(PtpPermissionId))]
        [InverseProperty(nameof(TblPermission.TblPanelTypePermission))]
        public virtual TblPermission PtpPermission { get; set; }
        [ForeignKey(nameof(PtpPtid))]
        [InverseProperty(nameof(TblPanelType.TblPanelTypePermission))]
        public virtual TblPanelType PtpPt { get; set; }
        [InverseProperty("OptPtp")]
        public virtual ICollection<TblOrganizationPanelType> TblOrganizationPanelType { get; set; }
    }
}
