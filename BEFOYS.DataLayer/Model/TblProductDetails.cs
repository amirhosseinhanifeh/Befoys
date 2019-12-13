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
        [Column("PD_ProductID")]
        public int PdProductId { get; set; }
        [Column("PD_PFID")]
        public int PdPfid { get; set; }
        [Column("PD_Value")]
        public string PdValue { get; set; }
        [Column("PD_Description")]
        public string PdDescription { get; set; }
        [Column("PD_PFIID")]
        public int? PdPfiid { get; set; }

        [ForeignKey(nameof(PdPfid))]
        [InverseProperty(nameof(TblProductFeatures.TblProductDetails))]
        public virtual TblProductFeatures PdPf { get; set; }
        [ForeignKey(nameof(PdPfiid))]
        [InverseProperty(nameof(TblProductFeatureItems.TblProductDetails))]
        public virtual TblProductFeatureItems PdPfi { get; set; }
        [ForeignKey(nameof(PdProductId))]
        [InverseProperty(nameof(TblProduct.TblProductDetails))]
        public virtual TblProduct PdProduct { get; set; }
    }
}
