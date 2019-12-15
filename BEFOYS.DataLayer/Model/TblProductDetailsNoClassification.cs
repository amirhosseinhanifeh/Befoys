using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductDetailsNoClassification")]
    public partial class TblProductDetailsNoClassification
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
        [Column("PFNC_IsAccept")]
        public bool? PfncIsAccept { get; set; }
        [Column("PFNC_Reason")]
        public string PfncReason { get; set; }

        [ForeignKey(nameof(PfncProductId))]
        [InverseProperty(nameof(TblProduct.TblProductDetailsNoClassification))]
        public virtual TblProduct PfncProduct { get; set; }
    }
}
