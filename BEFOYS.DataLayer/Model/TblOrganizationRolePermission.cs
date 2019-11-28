using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationRolePermission")]
    public partial class TblOrganizationRolePermission
    {
        [Key]
        [Column("ORP_ID")]
        public int OrpId { get; set; }
        [Column("ORP_Guid")]
        public Guid OrpGuid { get; set; }
        [Column("ORP_ORID")]
        public int OrpOrid { get; set; }
        [Column("ORP_PermissionID")]
        public int OrpPermissionId { get; set; }

        [ForeignKey(nameof(OrpOrid))]
        [InverseProperty(nameof(TblOrganizationRole.TblOrganizationRolePermission))]
        public virtual TblOrganizationRole OrpOr { get; set; }
        [ForeignKey(nameof(OrpPermissionId))]
        [InverseProperty(nameof(TblPermission.TblOrganizationRolePermission))]
        public virtual TblPermission OrpPermission { get; set; }
    }
}
