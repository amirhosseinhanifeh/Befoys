using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_PanelType")]
    public partial class TblPanelType
    {
        public TblPanelType()
        {
            TblOrganizationType = new HashSet<TblOrganizationType>();
            TblPanelTypeControl = new HashSet<TblPanelTypeControl>();
            TblPanelTypePermission = new HashSet<TblPanelTypePermission>();
        }

        [Key]
        [Column("PT_ID")]
        public int PtId { get; set; }
        [Column("PT_GUID")]
        public Guid PtGuid { get; set; }
        [Required]
        [Column("PT_Name")]
        [StringLength(50)]
        public string PtName { get; set; }
        [Required]
        [Column("PT_Display")]
        [StringLength(50)]
        public string PtDisplay { get; set; }
        [Column("PT_IsFree")]
        public bool PtIsFree { get; set; }
        [Column("PT_Price")]
        public int? PtPrice { get; set; }

        [InverseProperty("OtDefaultPt")]
        public virtual ICollection<TblOrganizationType> TblOrganizationType { get; set; }
        [InverseProperty("PtcPt")]
        public virtual ICollection<TblPanelTypeControl> TblPanelTypeControl { get; set; }
        [InverseProperty("PtpPt")]
        public virtual ICollection<TblPanelTypePermission> TblPanelTypePermission { get; set; }
    }
}
