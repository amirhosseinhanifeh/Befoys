using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationDocument")]
    public partial class TblOrganizationDocument
    {
        [Key]
        [Column("OD_ID")]
        public int OdId { get; set; }
        [Column("OD_Guid")]
        public Guid OdGuid { get; set; }
        [Column("OD_OrganizationID")]
        public int OdOrganizationId { get; set; }
        [Column("OD_DocumentID")]
        public int OdDocumentId { get; set; }

        [ForeignKey(nameof(OdDocumentId))]
        [InverseProperty(nameof(TblDocument.TblOrganizationDocument))]
        public virtual TblDocument OdDocument { get; set; }
        [ForeignKey(nameof(OdOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblOrganizationDocument))]
        public virtual TblOrganization OdOrganization { get; set; }
    }
}
