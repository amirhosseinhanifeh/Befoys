﻿using System;
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
            TblProductCode = new HashSet<TblProductCode>();
            TblProductColors = new HashSet<TblProductColors>();
            TblProductDetails = new HashSet<TblProductDetails>();
            TblProductDetailsNoClassification = new HashSet<TblProductDetailsNoClassification>();
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
        [Column("Product_BrandsID")]
        public int? ProductBrandsId { get; set; }
        [Column("Product_LoginID")]
        public int ProductLoginId { get; set; }
        [Column("Product_OrganizationId")]
        public int? ProductOrganizationId { get; set; }
        [Required]
        [Column("Product_Name")]
        public string ProductName { get; set; }
        [Column("Product_IsDelete")]
        public bool ProductIsDelete { get; set; }
        [Column("Product_Create")]
        public DateTime ProductCreate { get; set; }
        [Column("Product_Modify")]
        public DateTime ProductModify { get; set; }

        [ForeignKey(nameof(ProductBrandsId))]
        [InverseProperty(nameof(TblBrands.TblProduct))]
        public virtual TblBrands ProductBrands { get; set; }
        [ForeignKey(nameof(ProductLoginId))]
        [InverseProperty(nameof(TblLogin.TblProduct))]
        public virtual TblLogin ProductLogin { get; set; }
        [ForeignKey(nameof(ProductOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblProduct))]
        public virtual TblOrganization ProductOrganization { get; set; }
        [ForeignKey(nameof(ProductPcid))]
        [InverseProperty(nameof(TblProductCategory.TblProduct))]
        public virtual TblProductCategory ProductPc { get; set; }
        [InverseProperty("PcProduct")]
        public virtual ICollection<TblProductCode> TblProductCode { get; set; }
        [InverseProperty("PcProduct")]
        public virtual ICollection<TblProductColors> TblProductColors { get; set; }
        [InverseProperty("PdProduct")]
        public virtual ICollection<TblProductDetails> TblProductDetails { get; set; }
        [InverseProperty("PfncProduct")]
        public virtual ICollection<TblProductDetailsNoClassification> TblProductDetailsNoClassification { get; set; }
        [InverseProperty("PdProduct")]
        public virtual ICollection<TblProductDocument> TblProductDocument { get; set; }
        [InverseProperty("PoProduct")]
        public virtual ICollection<TblProductOrganization> TblProductOrganization { get; set; }
        [InverseProperty("PtProduct")]
        public virtual ICollection<TblProductTags> TblProductTags { get; set; }
    }
}
