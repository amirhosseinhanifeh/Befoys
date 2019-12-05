using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductDocument")]
    public partial class TblProductDocument
    {
        public TblProductDocument()
        {
            TblProductColors = new HashSet<TblProductColors>();
        }

        [Key]
        [Column("PD_ID")]
        public int PdId { get; set; }
        [Column("PD_Guid")]
        public Guid PdGuid { get; set; }
        [Column("PD_ProductID")]
        public int PdProductId { get; set; }
        [Column("PD_TypeCodeID")]
        public int PdTypeCodeId { get; set; }
        [Column("PD_KindCodeID")]
        public int PdKindCodeId { get; set; }
        [Column("PD_IsActive")]
        public bool PdIsActive { get; set; }
        [Column("PD_DocumentID")]
        public int PdDocumentId { get; set; }

        [ForeignKey(nameof(PdDocumentId))]
        [InverseProperty(nameof(TblDocument.TblProductDocument))]
        public virtual TblDocument PdDocument { get; set; }
        [ForeignKey(nameof(PdKindCodeId))]
        [InverseProperty(nameof(TblCode.TblProductDocumentPdKindCode))]
        public virtual TblCode PdKindCode { get; set; }
        [ForeignKey(nameof(PdProductId))]
        [InverseProperty(nameof(TblProduct.TblProductDocument))]
        public virtual TblProduct PdProduct { get; set; }
        [ForeignKey(nameof(PdTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblProductDocumentPdTypeCode))]
        public virtual TblCode PdTypeCode { get; set; }
        [InverseProperty("PcPd")]
        public virtual ICollection<TblProductColors> TblProductColors { get; set; }
    }
}
