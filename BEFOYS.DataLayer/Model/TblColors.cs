using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Colors")]
    public partial class TblColors
    {
        public TblColors()
        {
            TblProductColors = new HashSet<TblProductColors>();
            TblProductOrganizationQuantity = new HashSet<TblProductOrganizationQuantity>();
        }

        [Key]
        [Column("Colors_ID")]
        public int ColorsId { get; set; }
        [Column("Colors_Guid")]
        public Guid ColorsGuid { get; set; }
        [Column("Colors_CGID")]
        public int ColorsCgid { get; set; }
        [Column("Colors_TypeCodeID")]
        public int ColorsTypeCodeId { get; set; }
        [Required]
        [Column("Colors_Name")]
        [StringLength(100)]
        public string ColorsName { get; set; }
        [Required]
        [Column("Colors_Value")]
        [StringLength(100)]
        public string ColorsValue { get; set; }

        [ForeignKey(nameof(ColorsCgid))]
        [InverseProperty(nameof(TblColorsGroup.TblColors))]
        public virtual TblColorsGroup ColorsCg { get; set; }
        [ForeignKey(nameof(ColorsTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblColors))]
        public virtual TblCode ColorsTypeCode { get; set; }
        [InverseProperty("PcColors")]
        public virtual ICollection<TblProductColors> TblProductColors { get; set; }
        [InverseProperty("PoqColor")]
        public virtual ICollection<TblProductOrganizationQuantity> TblProductOrganizationQuantity { get; set; }
    }
}
