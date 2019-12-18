using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Organization")]
    public partial class TblOrganization
    {
        public TblOrganization()
        {
            InverseOrganizationMotherOrganization = new HashSet<TblOrganization>();
            TblAddress = new HashSet<TblAddress>();
            TblEmployee = new HashSet<TblEmployee>();
            TblMessage = new HashSet<TblMessage>();
            TblOrganizationBrand = new HashSet<TblOrganizationBrand>();
            TblOrganizationDocument = new HashSet<TblOrganizationDocument>();
            TblOrganizationInformation = new HashSet<TblOrganizationInformation>();
            TblOrganizationProductCategory = new HashSet<TblOrganizationProductCategory>();
            TblOrganizationRole = new HashSet<TblOrganizationRole>();
            TblOrganizationTransport = new HashSet<TblOrganizationTransport>();
            TblPanelTypeControl = new HashSet<TblPanelTypeControl>();
            TblProduct = new HashSet<TblProduct>();
            TblProductCode = new HashSet<TblProductCode>();
            TblProductCustomRequest = new HashSet<TblProductCustomRequest>();
            TblProductOrganization = new HashSet<TblProductOrganization>();
        }

        [Key]
        [Column("Organization_ID")]
        public int OrganizationId { get; set; }
        [Column("Organization_Guid")]
        public Guid OrganizationGuid { get; set; }
        [Column("Organization_OTID")]
        public int OrganizationOtid { get; set; }
        [Column("Organization_NameInformationID")]
        public int? OrganizationNameInformationId { get; set; }
        [Required]
        [Column("Organization_IsMotherOrganization")]
        public bool? OrganizationIsMotherOrganization { get; set; }
        [Column("Organization_MotherOrganizationID")]
        public int? OrganizationMotherOrganizationId { get; set; }
        [Column("Organization_IsBan")]
        public bool OrganizationIsBan { get; set; }
        [Column("Organization_IsDelete")]
        public bool OrganizationIsDelete { get; set; }
        [Column("Organization_IsRegistar")]
        public bool OrganizationIsRegistar { get; set; }
        [Column("Organization_IsActive")]
        public bool OrganizationIsActive { get; set; }
        [Column("Organization_CreateDate")]
        public DateTime OrganizationCreateDate { get; set; }
        [Column("Organization_ModifyDate")]
        public DateTime OrganizationModifyDate { get; set; }
        [Column("Organization_HasPanel")]
        public bool? OrganizationHasPanel { get; set; }

        [ForeignKey(nameof(OrganizationMotherOrganizationId))]
        [InverseProperty(nameof(TblOrganization.InverseOrganizationMotherOrganization))]
        public virtual TblOrganization OrganizationMotherOrganization { get; set; }
        [ForeignKey(nameof(OrganizationNameInformationId))]
        public virtual TblOrganizationInformation OrganizationNameInformation { get; set; }
        [ForeignKey(nameof(OrganizationOtid))]
        [InverseProperty(nameof(TblOrganizationType.TblOrganization))]
        public virtual TblOrganizationType OrganizationOt { get; set; }
        [InverseProperty(nameof(TblOrganization.OrganizationMotherOrganization))]
        public virtual ICollection<TblOrganization> InverseOrganizationMotherOrganization { get; set; }
        [InverseProperty("AddressOrganization")]
        public virtual ICollection<TblAddress> TblAddress { get; set; }
        [InverseProperty("EmployeeOrganization")]
        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
        [InverseProperty("MessageReceiverOrganization")]
        public virtual ICollection<TblMessage> TblMessage { get; set; }
        [InverseProperty("ObOrganization")]
        public virtual ICollection<TblOrganizationBrand> TblOrganizationBrand { get; set; }
        [InverseProperty("OdOrganization")]
        public virtual ICollection<TblOrganizationDocument> TblOrganizationDocument { get; set; }
        [InverseProperty("OiOrganization")]
        public virtual ICollection<TblOrganizationInformation> TblOrganizationInformation { get; set; }
        [InverseProperty("OpcOrganization")]
        public virtual ICollection<TblOrganizationProductCategory> TblOrganizationProductCategory { get; set; }
        [InverseProperty("OrOrganization")]
        public virtual ICollection<TblOrganizationRole> TblOrganizationRole { get; set; }
        [InverseProperty("OtOrganization")]
        public virtual ICollection<TblOrganizationTransport> TblOrganizationTransport { get; set; }
        [InverseProperty("PtcOrganization")]
        public virtual ICollection<TblPanelTypeControl> TblPanelTypeControl { get; set; }
        [InverseProperty("ProductOrganization")]
        public virtual ICollection<TblProduct> TblProduct { get; set; }
        [InverseProperty("PcOrganization")]
        public virtual ICollection<TblProductCode> TblProductCode { get; set; }
        [InverseProperty("PcrOrganiziton")]
        public virtual ICollection<TblProductCustomRequest> TblProductCustomRequest { get; set; }
        [InverseProperty("PoOrganization")]
        public virtual ICollection<TblProductOrganization> TblProductOrganization { get; set; }
    }
}
