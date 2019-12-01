using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductDetails")]
    public partial class TblProductDetails
    {
        [Key]
        [Column("PD_ID")]
        public int PdId { get; set; }
        [Column("PD_Guid")]
        public Guid PdGuid { get; set; }
        [Column("PD_Product")]
        public int PdProduct { get; set; }

        [ForeignKey(nameof(PdProduct))]
        [InverseProperty(nameof(TblProduct.TblProductDetails))]
        public virtual TblProduct PdProductNavigation { get; set; }
    }
}
