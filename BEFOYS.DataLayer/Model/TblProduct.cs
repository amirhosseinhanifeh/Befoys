using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Product")]
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblProductColors = new HashSet<TblProductColors>();
            TblProductDetails = new HashSet<TblProductDetails>();
            TblProductDocument = new HashSet<TblProductDocument>();
            TblProductOrganization = new HashSet<TblProductOrganization>();
            TblProductTags = new HashSet<TblProductTags>();
        }

        [Key]
        [Column("Product_ID")]
        public int ProductId { get; set; }
        [Column("Product_Guid")]
        public Guid ProductGuid { get; set; }
        [Column("Product_PCID")]
        public int ProductPcid { get; set; }
        [Required]
        [Column("Product_Name")]
        public string ProductName { get; set; }
        [Column("Product_BrandsID")]
        public int ProductBrandsId { get; set; }

        [ForeignKey(nameof(ProductBrandsId))]
        [InverseProperty(nameof(TblBrands.TblProduct))]
        public virtual TblBrands ProductBrands { get; set; }
        [ForeignKey(nameof(ProductPcid))]
        [InverseProperty(nameof(TblProductCategory.TblProduct))]
        public virtual TblProductCategory ProductPc { get; set; }
        [InverseProperty("PcProduct")]
        public virtual ICollection<TblProductColors> TblProductColors { get; set; }
        [InverseProperty("PdProductNavigation")]
        public virtual ICollection<TblProductDetails> TblProductDetails { get; set; }
        [InverseProperty("PdProduct")]
        public virtual ICollection<TblProductDocument> TblProductDocument { get; set; }
        [InverseProperty("PoProduct")]
        public virtual ICollection<TblProductOrganization> TblProductOrganization { get; set; }
        [InverseProperty("PtProduct")]
        public virtual ICollection<TblProductTags> TblProductTags { get; set; }
    }
}
