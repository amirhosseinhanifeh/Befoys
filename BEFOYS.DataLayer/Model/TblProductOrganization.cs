using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductOrganization")]
    public partial class TblProductOrganization
    {
        public TblProductOrganization()
        {
            TblProductCustomOrganizationForm = new HashSet<TblProductCustomOrganizationForm>();
            TblProductCustomRequest = new HashSet<TblProductCustomRequest>();
        }

        [Key]
        [Column("PO_ID")]
        public int PoId { get; set; }
        [Column("PO_Guid")]
        public Guid PoGuid { get; set; }
        [Column("PO_ProductID")]
        public int PoProductId { get; set; }
        [Column("PO_OrganizationID")]
        public int PoOrganizationId { get; set; }
        [Column("PO_SAID")]
        public int PoSaid { get; set; }
        [Column("PO_IsCustomization")]
        public bool PoIsCustomization { get; set; }
        [Column("PO_IsReject")]
        public bool PoIsReject { get; set; }
        [Column("PO_HasExperts")]
        public bool PoHasExperts { get; set; }
        [Column("PO_Count")]
        public int? PoCount { get; set; }
        [Column("PO_IsDelete")]
        public bool? PoIsDelete { get; set; }
        [Column("PO_IsHas")]
        public bool? PoIsHas { get; set; }
        [Column("PO_Description")]
        public string PoDescription { get; set; }
        [Column("PO_Code")]
        public string PoCode { get; set; }
        [Column("PO_GuaranteeID")]
        public int? PoGuaranteeId { get; set; }

        [ForeignKey(nameof(PoGuaranteeId))]
        [InverseProperty(nameof(TblGuarantee.TblProductOrganization))]
        public virtual TblGuarantee PoGuarantee { get; set; }
        [ForeignKey(nameof(PoOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblProductOrganization))]
        public virtual TblOrganization PoOrganization { get; set; }
        [ForeignKey(nameof(PoProductId))]
        [InverseProperty(nameof(TblProduct.TblProductOrganization))]
        public virtual TblProduct PoProduct { get; set; }
        [ForeignKey(nameof(PoSaid))]
        [InverseProperty(nameof(TblSiteArea.TblProductOrganization))]
        public virtual TblSiteArea PoSa { get; set; }
        [InverseProperty("PcofPo")]
        public virtual ICollection<TblProductCustomOrganizationForm> TblProductCustomOrganizationForm { get; set; }
        [InverseProperty("PcrPo")]
        public virtual ICollection<TblProductCustomRequest> TblProductCustomRequest { get; set; }
    }
}
