using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Permission")]
    public partial class TblPermission
    {
        public TblPermission()
        {
            TblGroupPermission = new HashSet<TblGroupPermission>();
            TblOrganizationRolePermission = new HashSet<TblOrganizationRolePermission>();
            TblPanelTypePermission = new HashSet<TblPanelTypePermission>();
        }

        [Key]
        [Column("Permission_ID")]
        public int PermissionId { get; set; }
        [Column("Permission_GUID")]
        public Guid PermissionGuid { get; set; }
        [Column("Permission_CodeID")]
        public int PermissionCodeId { get; set; }
        [Required]
        [Column("Permission_Name")]
        [StringLength(50)]
        public string PermissionName { get; set; }
        [Required]
        [Column("Permission_Display")]
        [StringLength(50)]
        public string PermissionDisplay { get; set; }
        [Required]
        [Column("Permission_IsFree")]
        public bool? PermissionIsFree { get; set; }

        [InverseProperty("GpPermission")]
        public virtual ICollection<TblGroupPermission> TblGroupPermission { get; set; }
        [InverseProperty("OrpPermission")]
        public virtual ICollection<TblOrganizationRolePermission> TblOrganizationRolePermission { get; set; }
        [InverseProperty("PtpPermission")]
        public virtual ICollection<TblPanelTypePermission> TblPanelTypePermission { get; set; }
    }
}
