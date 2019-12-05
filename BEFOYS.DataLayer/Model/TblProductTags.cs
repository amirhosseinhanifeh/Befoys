using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductTags")]
    public partial class TblProductTags
    {
        [Key]
        [Column("PT_ID")]
        public int PtId { get; set; }
        [Column("PT_Guid")]
        public Guid PtGuid { get; set; }
        [Column("PT_TagsID")]
        public int PtTagsId { get; set; }
        [Column("PT_ProductID")]
        public int PtProductId { get; set; }

        [ForeignKey(nameof(PtProductId))]
        [InverseProperty(nameof(TblProduct.TblProductTags))]
        public virtual TblProduct PtProduct { get; set; }
        [ForeignKey(nameof(PtTagsId))]
        [InverseProperty(nameof(TblTags.TblProductTags))]
        public virtual TblTags PtTags { get; set; }
    }
}
