using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCategory")]
    public partial class TblProductCategory
    {
        public TblProductCategory()
        {
            InversePcPcd = new HashSet<TblProductCategory>();
            TblOrganizationProductCategory = new HashSet<TblOrganizationProductCategory>();
            TblProduct = new HashSet<TblProduct>();
            TblProductCategoryDocument = new HashSet<TblProductCategoryDocument>();
            TblProductCategoryFeature = new HashSet<TblProductCategoryFeature>();
            TblProductCategoryTags = new HashSet<TblProductCategoryTags>();
        }

        [Key]
        [Column("PC_ID")]
        public int PcId { get; set; }
        [Column("PC_Guid")]
        public Guid PcGuid { get; set; }
        [Column("PC_PCDID")]
        public int? PcPcdid { get; set; }
        [Required]
        [Column("PC_Display")]
        [StringLength(50)]
        public string PcDisplay { get; set; }
        [Required]
        [Column("PC_Name")]
        [StringLength(50)]
        public string PcName { get; set; }
        [Column("PC_Commission")]
        public double PcCommission { get; set; }
        [Column("PC_ContractClause")]
        public string PcContractClause { get; set; }
        [Column("PC_IsBase")]
        public bool PcIsBase { get; set; }
        [Column("PC_IsActive")]
        public bool PcIsActive { get; set; }

        [ForeignKey(nameof(PcPcdid))]
        [InverseProperty(nameof(TblProductCategory.InversePcPcd))]
        public virtual TblProductCategory PcPcd { get; set; }
        [InverseProperty(nameof(TblProductCategory.PcPcd))]
        public virtual ICollection<TblProductCategory> InversePcPcd { get; set; }
        [InverseProperty("OpcPc")]
        public virtual ICollection<TblOrganizationProductCategory> TblOrganizationProductCategory { get; set; }
        [InverseProperty("ProductPc")]
        public virtual ICollection<TblProduct> TblProduct { get; set; }
        [InverseProperty("PcdPc")]
        public virtual ICollection<TblProductCategoryDocument> TblProductCategoryDocument { get; set; }
        [InverseProperty("PcfPc")]
        public virtual ICollection<TblProductCategoryFeature> TblProductCategoryFeature { get; set; }
        [InverseProperty("PctPc")]
        public virtual ICollection<TblProductCategoryTags> TblProductCategoryTags { get; set; }
    }
}
