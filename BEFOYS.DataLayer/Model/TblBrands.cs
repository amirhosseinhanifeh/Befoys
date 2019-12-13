using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Brands")]
    public partial class TblBrands
    {
        public TblBrands()
        {
            TblOrganizationBrand = new HashSet<TblOrganizationBrand>();
            TblProduct = new HashSet<TblProduct>();
        }

        [Key]
        [Column("Brands_ID")]
        public int BrandsId { get; set; }
        [Column("Brands_Guid")]
        public Guid BrandsGuid { get; set; }
        [Required]
        [Column("Brands_Name")]
        [StringLength(50)]
        public string BrandsName { get; set; }
        [Column("Brands_IsVerify")]
        public bool BrandsIsVerify { get; set; }
        [Column("Brands_CountryReferenceID")]
        public int? BrandsCountryReferenceId { get; set; }
        [Column("Brands_LogoDocumentID")]
        public int? BrandsLogoDocumentId { get; set; }

        [ForeignKey(nameof(BrandsCountryReferenceId))]
        [InverseProperty(nameof(TblCountry.TblBrands))]
        public virtual TblCountry BrandsCountryReference { get; set; }
        [ForeignKey(nameof(BrandsLogoDocumentId))]
        [InverseProperty(nameof(TblDocument.TblBrands))]
        public virtual TblDocument BrandsLogoDocument { get; set; }
        [InverseProperty("ObBrand")]
        public virtual ICollection<TblOrganizationBrand> TblOrganizationBrand { get; set; }
        [InverseProperty("ProductBrands")]
        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
