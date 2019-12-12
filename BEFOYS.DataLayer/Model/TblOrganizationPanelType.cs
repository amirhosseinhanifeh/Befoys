using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationPanelType")]
    public partial class TblOrganizationPanelType
    {
        [Key]
        [Column("OPT_ID")]
        public int OptId { get; set; }
        [Column("OPT_Guid")]
        public Guid OptGuid { get; set; }
        [Column("OPT_OTID")]
        public int OptOtid { get; set; }
        [Column("OPT_PTPID")]
        public int OptPtpid { get; set; }

        [ForeignKey(nameof(OptOtid))]
        [InverseProperty(nameof(TblOrganizationType.TblOrganizationPanelType))]
        public virtual TblOrganizationType OptOt { get; set; }
        [ForeignKey(nameof(OptPtpid))]
        [InverseProperty(nameof(TblPanelTypePermission.TblOrganizationPanelType))]
        public virtual TblPanelTypePermission OptPtp { get; set; }
    }
}
