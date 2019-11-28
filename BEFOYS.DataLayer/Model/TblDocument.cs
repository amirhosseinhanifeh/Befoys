using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Document")]
    public partial class TblDocument
    {
        public TblDocument()
        {
            TblLogin = new HashSet<TblLogin>();
            TblOrganizationDocument = new HashSet<TblOrganizationDocument>();
        }

        [Key]
        [Column("Document_ID")]
        public int DocumentId { get; set; }
        [Column("Document_GUID")]
        public Guid DocumentGuid { get; set; }
        [Column("Document_TypeCodeID")]
        public int DocumentTypeCodeId { get; set; }
        [Column("Document_ExternalServer")]
        public bool DocumentExternalServer { get; set; }
        [Column("Document_ExternalServerAddress")]
        [StringLength(50)]
        public string DocumentExternalServerAddress { get; set; }
        [Required]
        [Column("Document_Path", TypeName = "ntext")]
        public string DocumentPath { get; set; }
        [Required]
        [Column("Document_FolderName")]
        [StringLength(50)]
        public string DocumentFolderName { get; set; }
        [Required]
        [Column("Document_FileName")]
        [StringLength(50)]
        public string DocumentFileName { get; set; }

        [ForeignKey(nameof(DocumentTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblDocument))]
        public virtual TblCode DocumentTypeCode { get; set; }
        [InverseProperty("LoginPictureDocument")]
        public virtual ICollection<TblLogin> TblLogin { get; set; }
        [InverseProperty("OdDocument")]
        public virtual ICollection<TblOrganizationDocument> TblOrganizationDocument { get; set; }
    }
}
