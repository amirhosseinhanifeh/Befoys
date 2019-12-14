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
            TblBrands = new HashSet<TblBrands>();
            TblCountry = new HashSet<TblCountry>();
            TblLogin = new HashSet<TblLogin>();
            TblOrganizationDocument = new HashSet<TblOrganizationDocument>();
            TblProductCategoryDocument = new HashSet<TblProductCategoryDocument>();
            TblProductCustomRequestAttachment = new HashSet<TblProductCustomRequestAttachment>();
            TblProductCustomRequestMessage = new HashSet<TblProductCustomRequestMessage>();
            TblProductDocument = new HashSet<TblProductDocument>();
            TblUnit = new HashSet<TblUnit>();
        }

        [Key]
        [Column("Document_ID")]
        public int DocumentId { get; set; }
        [Column("Document_GUID")]
        public Guid DocumentGuid { get; set; }
        [Column("Document_ServerID")]
        public int DocumentServerId { get; set; }
        [Column("Document_TypeCodeID")]
        public int DocumentTypeCodeId { get; set; }
        [Required]
        [Column("Document_FolderName")]
        [StringLength(50)]
        public string DocumentFolderName { get; set; }
        [Required]
        [Column("Document_FileName")]
        [StringLength(50)]
        public string DocumentFileName { get; set; }

        [ForeignKey(nameof(DocumentServerId))]
        [InverseProperty(nameof(TblServer.TblDocument))]
        public virtual TblServer DocumentServer { get; set; }
        [ForeignKey(nameof(DocumentTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblDocument))]
        public virtual TblCode DocumentTypeCode { get; set; }
        [InverseProperty("BrandsLogoDocument")]
        public virtual ICollection<TblBrands> TblBrands { get; set; }
        [InverseProperty("CountryFlagDocument")]
        public virtual ICollection<TblCountry> TblCountry { get; set; }
        [InverseProperty("LoginPictureDocument")]
        public virtual ICollection<TblLogin> TblLogin { get; set; }
        [InverseProperty("OdDocument")]
        public virtual ICollection<TblOrganizationDocument> TblOrganizationDocument { get; set; }
        [InverseProperty("PcdDocument")]
        public virtual ICollection<TblProductCategoryDocument> TblProductCategoryDocument { get; set; }
        [InverseProperty("PcraDocument")]
        public virtual ICollection<TblProductCustomRequestAttachment> TblProductCustomRequestAttachment { get; set; }
        [InverseProperty("PcrmDocument")]
        public virtual ICollection<TblProductCustomRequestMessage> TblProductCustomRequestMessage { get; set; }
        [InverseProperty("PdDocument")]
        public virtual ICollection<TblProductDocument> TblProductDocument { get; set; }
        [InverseProperty("UnitLogoDocument")]
        public virtual ICollection<TblUnit> TblUnit { get; set; }
    }
}
