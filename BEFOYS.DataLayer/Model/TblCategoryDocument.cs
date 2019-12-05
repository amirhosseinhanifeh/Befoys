using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_CategoryDocument")]
    public partial class TblCategoryDocument
    {
        [Key]
        [Column("CD_ID")]
        public int CdId { get; set; }
        [Column("CD_Guid")]
        public Guid CdGuid { get; set; }
        [Column("CD_PCID")]
        public int CdPcid { get; set; }
        [Column("CD_DocumentID")]
        public int CdDocumentId { get; set; }
        [Column("CD_IsActive")]
        public bool CdIsActive { get; set; }
        [Column("CD_TypeCodeID")]
        public int CdTypeCodeId { get; set; }


    }
}
