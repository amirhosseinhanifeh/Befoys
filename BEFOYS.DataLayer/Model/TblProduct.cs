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
            TblProductDetails = new HashSet<TblProductDetails>();
            TblProductOrganization = new HashSet<TblProductOrganization>();
        }

        [Key]
        [Column("Product_ID")]
        public int ProductId { get; set; }
        [Column("Product_Guid")]
        public Guid ProductGuid { get; set; }

        [InverseProperty("PdProductNavigation")]
        public virtual ICollection<TblProductDetails> TblProductDetails { get; set; }
        [InverseProperty("PoProduct")]
        public virtual ICollection<TblProductOrganization> TblProductOrganization { get; set; }
    }
}
