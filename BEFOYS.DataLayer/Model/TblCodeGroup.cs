using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_CodeGroup")]
    public partial class TblCodeGroup
    {
        public TblCodeGroup()
        {
            TblCode = new HashSet<TblCode>();
        }

        [Key]
        [Column("CG_ID")]
        public int CgId { get; set; }
        [Column("CG_Guid")]
        public Guid CgGuid { get; set; }
        [Required]
        [Column("CG_Name")]
        [StringLength(100)]
        public string CgName { get; set; }
        [Required]
        [Column("CG_Display")]
        [StringLength(100)]
        public string CgDisplay { get; set; }

        [InverseProperty("CodeCg")]
        public virtual ICollection<TblCode> TblCode { get; set; }
    }
}
