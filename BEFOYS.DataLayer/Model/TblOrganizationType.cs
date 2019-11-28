﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationType")]
    public partial class TblOrganizationType
    {
        public TblOrganizationType()
        {
            TblOrganization = new HashSet<TblOrganization>();
            TblOrganizationDocumentNavigator = new HashSet<TblOrganizationDocumentNavigator>();
        }

        [Key]
        [Column("OT_ID")]
        public int OtId { get; set; }
        [Column("OT_Guid")]
        public Guid OtGuid { get; set; }
        [Required]
        [Column("OT_Name")]
        [StringLength(100)]
        public string OtName { get; set; }
        [Required]
        [Column("OT_Display")]
        [StringLength(100)]
        public string OtDisplay { get; set; }

        [InverseProperty("OrganizationOt")]
        public virtual ICollection<TblOrganization> TblOrganization { get; set; }
        [InverseProperty("OdnOt")]
        public virtual ICollection<TblOrganizationDocumentNavigator> TblOrganizationDocumentNavigator { get; set; }
    }
}