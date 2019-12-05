using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCategoryDocument")]
    public partial class TblProductCategoryDocument
    {
        [Key]
        [Column("PCD_ID")]
        public int PcdId { get; set; }
        [Column("PCD_Guid")]
        public Guid PcdGuid { get; set; }
        [Column("PCD_PCID")]
        public int PcdPcid { get; set; }
        [Column("PCD_DocumentID")]
        public int PcdDocumentId { get; set; }
        [Column("PCD_IsActive")]
        public bool PcdIsActive { get; set; }
        [Column("PCD_TypeCodeID")]
        public int PcdTypeCodeId { get; set; }

        [ForeignKey(nameof(PcdDocumentId))]
        [InverseProperty(nameof(TblDocument.TblProductCategoryDocument))]
        public virtual TblDocument PcdDocument { get; set; }
        [ForeignKey(nameof(PcdPcid))]
        [InverseProperty(nameof(TblProductCategory.TblProductCategoryDocument))]
        public virtual TblProductCategory PcdPc { get; set; }
        [ForeignKey(nameof(PcdTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblProductCategoryDocument))]
        public virtual TblCode PcdTypeCode { get; set; }
    }
}
