using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductFeatureGroup")]
    public partial class TblProductFeatureGroup
    {
        public TblProductFeatureGroup()
        {
            TblProductCategoryFeature = new HashSet<TblProductCategoryFeature>();
            TblProductFeatures = new HashSet<TblProductFeatures>();
        }

        [Key]
        [Column("PFG_ID")]
        public int PfgId { get; set; }
        [Required]
        [Column("PFG_Name")]
        [StringLength(50)]
        public string PfgName { get; set; }
        [Column("PFG_IsActive")]
        public bool PfgIsActive { get; set; }
        [Column("PFG_Guid")]
        public Guid PfgGuid { get; set; }

        [InverseProperty("PcfPfg")]
        public virtual ICollection<TblProductCategoryFeature> TblProductCategoryFeature { get; set; }
        [InverseProperty("PfPfg")]
        public virtual ICollection<TblProductFeatures> TblProductFeatures { get; set; }
    }
}
