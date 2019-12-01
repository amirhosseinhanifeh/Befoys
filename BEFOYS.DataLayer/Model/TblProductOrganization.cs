using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductOrganization")]
    public partial class TblProductOrganization
    {
        [Key]
        [Column("PO_ID")]
        public int PoId { get; set; }
        [Column("PO_Guid")]
        public Guid? PoGuid { get; set; }
        [Column("PO_ProductID")]
        public int? PoProductId { get; set; }
        [Column("PO_OrganizationID")]
        public int? PoOrganizationId { get; set; }
        [Column("PO_SAID")]
        public int? PoSaid { get; set; }

        [ForeignKey(nameof(PoOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblProductOrganization))]
        public virtual TblOrganization PoOrganization { get; set; }
        [ForeignKey(nameof(PoProductId))]
        [InverseProperty(nameof(TblProduct.TblProductOrganization))]
        public virtual TblProduct PoProduct { get; set; }
        [ForeignKey(nameof(PoSaid))]
        [InverseProperty(nameof(TblSiteArea.TblProductOrganization))]
        public virtual TblSiteArea PoSa { get; set; }
    }
}
