using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductFeatures")]
    public partial class TblProductFeatures
    {
        public TblProductFeatures()
        {
            TblProductDetails = new HashSet<TblProductDetails>();
            TblProductFeatureItems = new HashSet<TblProductFeatureItems>();
        }

        [Key]
        [Column("PF_ID")]
        public int PfId { get; set; }
        [Column("PF_Guid")]
        public Guid PfGuid { get; set; }
        [Required]
        [Column("PF_Name")]
        public string PfName { get; set; }
        [Required]
        [Column("PF_Display")]
        public string PfDisplay { get; set; }
        [Column("PF_IsActive")]
        public bool PfIsActive { get; set; }
        [Column("PF_PFGID")]
        public int PfPfgid { get; set; }
        [Column("PF_TypeCodeID")]
        public int PfTypeCodeId { get; set; }

        [ForeignKey(nameof(PfPfgid))]
        [InverseProperty(nameof(TblProductFeatureGroup.TblProductFeatures))]
        public virtual TblProductFeatureGroup PfPfg { get; set; }
        [ForeignKey(nameof(PfTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblProductFeatures))]
        public virtual TblCode PfTypeCode { get; set; }
        [InverseProperty("PdPf")]
        public virtual ICollection<TblProductDetails> TblProductDetails { get; set; }
        [InverseProperty("PfiPf")]
        public virtual ICollection<TblProductFeatureItems> TblProductFeatureItems { get; set; }
    }
}
