using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductFeatureItems")]
    public partial class TblProductFeatureItems
    {
        public TblProductFeatureItems()
        {
            TblProductDetails = new HashSet<TblProductDetails>();
        }

        [Key]
        [Column("PFI_ID")]
        public int PfiId { get; set; }
        [Column("PFI_Guid")]
        public Guid PfiGuid { get; set; }
        [Required]
        [Column("PFI_Value")]
        public string PfiValue { get; set; }
        [Column("PFI_PFID")]
        public int PfiPfid { get; set; }

        [ForeignKey(nameof(PfiPfid))]
        [InverseProperty(nameof(TblProductFeatures.TblProductFeatureItems))]
        public virtual TblProductFeatures PfiPf { get; set; }
        [InverseProperty("PdPfi")]
        public virtual ICollection<TblProductDetails> TblProductDetails { get; set; }
    }
}
