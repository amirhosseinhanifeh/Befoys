using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationTransport")]
    public partial class TblOrganizationTransport
    {
        [Key]
        [Column("OT_ID")]
        public int OtId { get; set; }
        [Column("OT_Guid")]
        public Guid OtGuid { get; set; }
        [Column("OT_OrganizationID")]
        public int OtOrganizationId { get; set; }
        [Column("OT_ProvinceID")]
        public int OtProvinceId { get; set; }
        [Column("OT_MinInvoicePrice")]
        public int OtMinInvoicePrice { get; set; }
        [Column("OT_MinInvoicePriceFree")]
        public int? OtMinInvoicePriceFree { get; set; }
        [Column("OT_Price")]
        public int? OtPrice { get; set; }

        [ForeignKey(nameof(OtOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblOrganizationTransport))]
        public virtual TblOrganization OtOrganization { get; set; }
        [ForeignKey(nameof(OtProvinceId))]
        [InverseProperty(nameof(TblProvince.TblOrganizationTransport))]
        public virtual TblProvince OtProvince { get; set; }
    }
}
