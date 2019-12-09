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
            TblEmployee = new HashSet<TblEmployee>();
            TblOrganizationDocument = new HashSet<TblOrganizationDocument>();
            TblOrganizationInformation = new HashSet<TblOrganizationInformation>();
            TblOrganizationRole = new HashSet<TblOrganizationRole>();
            TblPanelTypeControl = new HashSet<TblPanelTypeControl>();
            TblProductOrganization = new HashSet<TblProductOrganization>();
        }

        [Key]
        [Column("Organization_ID")]
        public int OrganizationId { get; set; }
        [Column("Organization_Guid")]
        public Guid OrganizationGuid { get; set; }
        [Column("Organization_OTID")]
        public int OrganizationOtid { get; set; }
        [Column("Organization_DefaultPTID")]
        public int OrganizationDefaultPtid { get; set; }
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

        [ForeignKey(nameof(OrganizationDefaultPtid))]
        [InverseProperty(nameof(TblPanelType.TblOrganization))]
        public virtual TblPanelType OrganizationDefaultPt { get; set; }
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
        [InverseProperty("EmployeeOrganization")]
        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
        [InverseProperty("OdOrganization")]
        public virtual ICollection<TblOrganizationDocument> TblOrganizationDocument { get; set; }
        [InverseProperty("OiOrganization")]
        public virtual ICollection<TblOrganizationInformation> TblOrganizationInformation { get; set; }
        [InverseProperty("OrOrganization")]
        public virtual ICollection<TblOrganizationRole> TblOrganizationRole { get; set; }
        [InverseProperty("PtcOrganization")]
        public virtual ICollection<TblPanelTypeControl> TblPanelTypeControl { get; set; }
        [InverseProperty("PoOrganization")]
        public virtual ICollection<TblProductOrganization> TblProductOrganization { get; set; }
    }
}
