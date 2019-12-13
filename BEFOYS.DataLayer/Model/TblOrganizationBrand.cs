using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationBrand")]
    public partial class TblOrganizationBrand
    {
        [Key]
        [Column("OB_ID")]
        public int ObId { get; set; }
        [Column("OB_Guid")]
        public Guid ObGuid { get; set; }
        [Column("OB_OrganizationID")]
        public int ObOrganizationId { get; set; }
        [Column("OB_BrandID")]
        public int ObBrandId { get; set; }

        [ForeignKey(nameof(ObBrandId))]
        [InverseProperty(nameof(TblBrands.TblOrganizationBrand))]
        public virtual TblBrands ObBrand { get; set; }
        [ForeignKey(nameof(ObOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblOrganizationBrand))]
        public virtual TblOrganization ObOrganization { get; set; }
    }
}
