using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Address")]
    public partial class TblAddress
    {
        public TblAddress()
        {
            TblPhone = new HashSet<TblPhone>();
        }

        [Key]
        [Column("Address_ID")]
        public int AddressId { get; set; }
        [Column("Address_GUID")]
        public Guid AddressGuid { get; set; }
        [Required]
        [Column("Address_Text", TypeName = "ntext")]
        public string AddressText { get; set; }
        [Column("Address_CityID")]
        public int AddressCityId { get; set; }
        [Column("Address_IsSetGPS")]
        public bool AddressIsSetGps { get; set; }
        [Column("Address_GPSLat")]
        [StringLength(50)]
        public string AddressGpslat { get; set; }
        [Column("Address_GPSLong")]
        [StringLength(50)]
        public string AddressGpslong { get; set; }
        [Column("Address_TypeCodeID")]
        public int AddressTypeCodeId { get; set; }
        [Column("Address_OrganizationID")]
        public int AddressOrganizationId { get; set; }

        [ForeignKey(nameof(AddressCityId))]
        [InverseProperty(nameof(TblCity.TblAddress))]
        public virtual TblCity AddressCity { get; set; }
        [ForeignKey(nameof(AddressOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblAddress))]
        public virtual TblOrganization AddressOrganization { get; set; }
        [ForeignKey(nameof(AddressTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblAddress))]
        public virtual TblCode AddressTypeCode { get; set; }
        [InverseProperty("PhoneAddress")]
        public virtual ICollection<TblPhone> TblPhone { get; set; }
    }
}
