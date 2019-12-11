using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductOrganizationDetails")]
    public partial class TblProductOrganizationDetails
    {
        [Key]
        [Column("POD_ID")]
        public int PodId { get; set; }
        [Column("POD_Guid")]
        public Guid PodGuid { get; set; }
        [Column("POD_OrganizationID")]
        public int PodOrganizationId { get; set; }
    }
}
