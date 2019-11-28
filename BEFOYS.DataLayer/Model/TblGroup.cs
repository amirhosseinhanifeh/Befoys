using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Group")]
    public partial class TblGroup
    {
        public TblGroup()
        {
            TblGroupPermission = new HashSet<TblGroupPermission>();
        }

        [Key]
        [Column("Group_ID")]
        public int GroupId { get; set; }
        [Column("Group_GUID")]
        public Guid GroupGuid { get; set; }
        [Column("Group_CodeID")]
        public int GroupCodeId { get; set; }
        [Required]
        [Column("Group_Name")]
        [StringLength(50)]
        public string GroupName { get; set; }
        [Required]
        [Column("Group_Display")]
        [StringLength(50)]
        public string GroupDisplay { get; set; }

        [InverseProperty("GpGroup")]
        public virtual ICollection<TblGroupPermission> TblGroupPermission { get; set; }
    }
}
