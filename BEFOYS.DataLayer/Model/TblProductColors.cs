using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductColors")]
    public partial class TblProductColors
    {
        [Key]
        [Column("PC_ID")]
        public int PcId { get; set; }
        [Column("PC_Guid")]
        public Guid PcGuid { get; set; }
        [Column("PC_ColorsID")]
        public int PcColorsId { get; set; }
        [Column("PC_ProductID")]
        public int PcProductId { get; set; }
        [Column("PC_PDID")]
        public int PcPdid { get; set; }

        [ForeignKey(nameof(PcColorsId))]
        [InverseProperty(nameof(TblColors.TblProductColors))]
        public virtual TblColors PcColors { get; set; }
        [ForeignKey(nameof(PcPdid))]
        [InverseProperty(nameof(TblProductDocument.TblProductColors))]
        public virtual TblProductDocument PcPd { get; set; }
        [ForeignKey(nameof(PcProductId))]
        [InverseProperty(nameof(TblProduct.TblProductColors))]
        public virtual TblProduct PcProduct { get; set; }
    }
}
