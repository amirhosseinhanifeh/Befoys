using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductFeatureNoClassification")]
    public partial class TblProductFeatureNoClassification
    {
        [Key]
        [Column("PFNC_ID")]
        public int PfncId { get; set; }
        [Column("PFNC_Guid")]
        public Guid PfncGuid { get; set; }
        [Required]
        [Column("PFNC_Value")]
        public string PfncValue { get; set; }
        [Column("PFNC_ProductID")]
        public int PfncProductId { get; set; }

        [ForeignKey(nameof(PfncProductId))]
        [InverseProperty(nameof(TblProduct.TblProductFeatureNoClassification))]
        public virtual TblProduct PfncProduct { get; set; }
    }
}
