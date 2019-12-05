using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCategoryTags")]
    public partial class TblProductCategoryTags
    {
        [Key]
        [Column("PCT_ID")]
        public int PctId { get; set; }
        [Column("PCT_PCID")]
        public int PctPcid { get; set; }
        [Column("PCT_TagsID")]
        public int PctTagsId { get; set; }
        [Column("PCT_Guid")]
        public Guid PctGuid { get; set; }

        [ForeignKey(nameof(PctPcid))]
        [InverseProperty(nameof(TblProductCategory.TblProductCategoryTags))]
        public virtual TblProductCategory PctPc { get; set; }
        [ForeignKey(nameof(PctTagsId))]
        [InverseProperty(nameof(TblTags.TblProductCategoryTags))]
        public virtual TblTags PctTags { get; set; }
    }
}
