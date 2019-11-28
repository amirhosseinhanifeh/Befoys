using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_GroupPermission")]
    public partial class TblGroupPermission
    {
        [Key]
        [Column("GP_ID")]
        public int GpId { get; set; }
        [Column("GP_GUID")]
        public Guid GpGuid { get; set; }
        [Column("GP_PermissionID")]
        public int GpPermissionId { get; set; }
        [Column("GP_GroupID")]
        public int GpGroupId { get; set; }

        [ForeignKey(nameof(GpGroupId))]
        [InverseProperty(nameof(TblGroup.TblGroupPermission))]
        public virtual TblGroup GpGroup { get; set; }
        [ForeignKey(nameof(GpPermissionId))]
        [InverseProperty(nameof(TblPermission.TblGroupPermission))]
        public virtual TblPermission GpPermission { get; set; }
    }
}
