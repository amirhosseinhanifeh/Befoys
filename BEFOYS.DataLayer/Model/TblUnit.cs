using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Unit")]
    public partial class TblUnit
    {
        public TblUnit()
        {
            InverseUnitUint = new HashSet<TblUnit>();
        }

        [Key]
        [Column("Unit_ID")]
        public int UnitId { get; set; }
        [Column("Unit_Guid")]
        public Guid UnitGuid { get; set; }
        [Required]
        [Column("Unit_Name")]
        [StringLength(50)]
        public string UnitName { get; set; }
        [Column("Unit_UintID")]
        public int UnitUintId { get; set; }
        [Column("Unit_IsBase")]
        public bool UnitIsBase { get; set; }
        [Column("Unit_XChange")]
        public double UnitXchange { get; set; }
        [Column("Unit_Symbol")]
        [StringLength(50)]
        public string UnitSymbol { get; set; }
        [Column("Unit_LogoDocumentID")]
        public int? UnitLogoDocumentId { get; set; }
        [Column("Unit_UGID")]
        public int UnitUgid { get; set; }

        [ForeignKey(nameof(UnitLogoDocumentId))]
        [InverseProperty(nameof(TblDocument.TblUnit))]
        public virtual TblDocument UnitLogoDocument { get; set; }
        [ForeignKey(nameof(UnitUgid))]
        [InverseProperty(nameof(TblUnitGroup.TblUnit))]
        public virtual TblUnitGroup UnitUg { get; set; }
        [ForeignKey(nameof(UnitUintId))]
        [InverseProperty(nameof(TblUnit.InverseUnitUint))]
        public virtual TblUnit UnitUint { get; set; }
        [InverseProperty(nameof(TblUnit.UnitUint))]
        public virtual ICollection<TblUnit> InverseUnitUint { get; set; }
    }
}
