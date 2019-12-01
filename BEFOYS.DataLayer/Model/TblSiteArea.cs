using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_SiteArea")]
    public partial class TblSiteArea
    {
        public TblSiteArea()
        {
            TblProductOrganization = new HashSet<TblProductOrganization>();
        }

        [Key]
        [Column("SA_ID")]
        public int SaId { get; set; }
        [Column("SA_Guid")]
        public Guid? SaGuid { get; set; }

        [InverseProperty("PoSa")]
        public virtual ICollection<TblProductOrganization> TblProductOrganization { get; set; }
    }
}
