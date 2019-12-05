using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ColorsGroup")]
    public partial class TblColorsGroup
    {
        public TblColorsGroup()
        {
            TblColors = new HashSet<TblColors>();
        }

        [Key]
        [Column("CG_ID")]
        public int CgId { get; set; }
        [Column("CG_Guid")]
        public Guid CgGuid { get; set; }
        [Required]
        [Column("CG_Name")]
        [StringLength(50)]
        public string CgName { get; set; }

        [InverseProperty("ColorsCg")]
        public virtual ICollection<TblColors> TblColors { get; set; }
    }
}
