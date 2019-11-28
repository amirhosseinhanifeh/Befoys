using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_PanelTypeControl")]
    public partial class TblPanelTypeControl
    {
        [Key]
        [Column("PTC_ID")]
        public int PtcId { get; set; }
        [Column("PTC_GUID")]
        public Guid PtcGuid { get; set; }
        [Column("PTC_PTID")]
        public int PtcPtid { get; set; }
        [Column("PTC_OrganizationID")]
        public int PtcOrganizationId { get; set; }
        [Column("PTC_StartDate")]
        public DateTime PtcStartDate { get; set; }
        [Column("PTC_FinshDate")]
        public DateTime PtcFinshDate { get; set; }

        [ForeignKey(nameof(PtcOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblPanelTypeControl))]
        public virtual TblOrganization PtcOrganization { get; set; }
        [ForeignKey(nameof(PtcPtid))]
        [InverseProperty(nameof(TblPanelType.TblPanelTypeControl))]
        public virtual TblPanelType PtcPt { get; set; }
    }
}
