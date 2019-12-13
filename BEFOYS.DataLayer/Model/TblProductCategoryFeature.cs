using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCategoryFeature")]
    public partial class TblProductCategoryFeature
    {
        [Key]
        [Column("PCF_ID")]
        public int PcfId { get; set; }
        [Column("PCF_Guid")]
        public Guid PcfGuid { get; set; }
        [Column("PCF_PCID")]
        public int PcfPcid { get; set; }
        [Column("PCF_PFGID")]
        public int PcfPfgid { get; set; }
        [Column("PCF_IsActive")]
        public bool PcfIsActive { get; set; }

        [ForeignKey(nameof(PcfPcid))]
        [InverseProperty(nameof(TblProductCategory.TblProductCategoryFeature))]
        public virtual TblProductCategory PcfPc { get; set; }
        [ForeignKey(nameof(PcfPfgid))]
        [InverseProperty(nameof(TblProductFeatureGroup.TblProductCategoryFeature))]
        public virtual TblProductFeatureGroup PcfPfg { get; set; }
    }
}
