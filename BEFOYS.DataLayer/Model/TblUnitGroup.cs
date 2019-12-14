using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_UnitGroup")]
    public partial class TblUnitGroup
    {
        public TblUnitGroup()
        {
            TblUnit = new HashSet<TblUnit>();
        }

        [Key]
        [Column("UG_ID")]
        public int UgId { get; set; }
        [Column("UG_Guid")]
        public Guid? UgGuid { get; set; }
        [Column("UG_Name")]
        [StringLength(50)]
        public string UgName { get; set; }

        [InverseProperty("UnitUg")]
        public virtual ICollection<TblUnit> TblUnit { get; set; }
    }
}
