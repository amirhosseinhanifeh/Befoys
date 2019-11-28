using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Code")]
    public partial class TblCode
    {
        public TblCode()
        {
            TblAddress = new HashSet<TblAddress>();
            TblDocument = new HashSet<TblDocument>();
            TblOrganizationDocumentFeaturesOdfKindCode = new HashSet<TblOrganizationDocumentFeatures>();
            TblOrganizationDocumentFeaturesOdfTypeCode = new HashSet<TblOrganizationDocumentFeatures>();
            TblOrganizationInformation = new HashSet<TblOrganizationInformation>();
            TblPhone = new HashSet<TblPhone>();
        }

        [Key]
        [Column("Code_ID")]
        public int CodeId { get; set; }
        [Column("Code_GUID")]
        public Guid CodeGuid { get; set; }
        [Column("Code_CGID")]
        public int CodeCgid { get; set; }
        [Required]
        [Column("Code_Name")]
        [StringLength(100)]
        public string CodeName { get; set; }
        [Required]
        [Column("Code_Display")]
        [StringLength(100)]
        public string CodeDisplay { get; set; }

        [ForeignKey(nameof(CodeCgid))]
        [InverseProperty(nameof(TblCodeGroup.TblCode))]
        public virtual TblCodeGroup CodeCg { get; set; }
        [InverseProperty("AddressTypeCode")]
        public virtual ICollection<TblAddress> TblAddress { get; set; }
        [InverseProperty("DocumentTypeCode")]
        public virtual ICollection<TblDocument> TblDocument { get; set; }
        [InverseProperty(nameof(TblOrganizationDocumentFeatures.OdfKindCode))]
        public virtual ICollection<TblOrganizationDocumentFeatures> TblOrganizationDocumentFeaturesOdfKindCode { get; set; }
        [InverseProperty(nameof(TblOrganizationDocumentFeatures.OdfTypeCode))]
        public virtual ICollection<TblOrganizationDocumentFeatures> TblOrganizationDocumentFeaturesOdfTypeCode { get; set; }
        [InverseProperty("OiTypeCode")]
        public virtual ICollection<TblOrganizationInformation> TblOrganizationInformation { get; set; }
        [InverseProperty("PhoneTypeCode")]
        public virtual ICollection<TblPhone> TblPhone { get; set; }
    }
}
