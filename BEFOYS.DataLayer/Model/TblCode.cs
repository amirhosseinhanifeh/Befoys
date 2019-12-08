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
            TblColors = new HashSet<TblColors>();
            TblDocument = new HashSet<TblDocument>();
            TblEmployee = new HashSet<TblEmployee>();
            TblOrganizationFeaturesOdfKindCode = new HashSet<TblOrganizationFeatures>();
            TblOrganizationFeaturesOdfTypeCode = new HashSet<TblOrganizationFeatures>();
            TblOrganizationInformation = new HashSet<TblOrganizationInformation>();
            TblPhone = new HashSet<TblPhone>();
            TblProductCategoryDocument = new HashSet<TblProductCategoryDocument>();
            TblProductDocumentPdKindCode = new HashSet<TblProductDocument>();
            TblProductDocumentPdTypeCode = new HashSet<TblProductDocument>();
        }

        [Key]
        [Column("Code_ID")]
        public int CodeId { get; set; }
        [Column("Code_GUID")]
        public Guid CodeGuid { get; set; }
        [Column("Code_CGID")]
        public int CodeCgid { get; set; }
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
        [InverseProperty("ColorsTypeCode")]
        public virtual ICollection<TblColors> TblColors { get; set; }
        [InverseProperty("DocumentTypeCode")]
        public virtual ICollection<TblDocument> TblDocument { get; set; }
        [InverseProperty("EmployeeTypeCode")]
        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
        [InverseProperty(nameof(TblOrganizationFeatures.OdfKindCode))]
        public virtual ICollection<TblOrganizationFeatures> TblOrganizationFeaturesOdfKindCode { get; set; }
        [InverseProperty(nameof(TblOrganizationFeatures.OdfTypeCode))]
        public virtual ICollection<TblOrganizationFeatures> TblOrganizationFeaturesOdfTypeCode { get; set; }
        [InverseProperty("OiTypeCode")]
        public virtual ICollection<TblOrganizationInformation> TblOrganizationInformation { get; set; }
        [InverseProperty("PhoneTypeCode")]
        public virtual ICollection<TblPhone> TblPhone { get; set; }
        [InverseProperty("PcdTypeCode")]
        public virtual ICollection<TblProductCategoryDocument> TblProductCategoryDocument { get; set; }
        [InverseProperty(nameof(TblProductDocument.PdKindCode))]
        public virtual ICollection<TblProductDocument> TblProductDocumentPdKindCode { get; set; }
        [InverseProperty(nameof(TblProductDocument.PdTypeCode))]
        public virtual ICollection<TblProductDocument> TblProductDocumentPdTypeCode { get; set; }
    }
}
