using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Phone")]
    public partial class TblPhone
    {
        [Key]
        [Column("Phone_ID")]
        public int PhoneId { get; set; }
        [Column("Phone_GUID")]
        public Guid PhoneGuid { get; set; }
        [Column("Phone_TypeCodeID")]
        public int PhoneTypeCodeId { get; set; }
        [Column("Phone_AreaCodeID")]
        public int PhoneAreaCodeId { get; set; }
        [Required]
        [Column("Phone_Number")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Column("Phone_AddressID")]
        public int PhoneAddressId { get; set; }

        [ForeignKey(nameof(PhoneAddressId))]
        [InverseProperty(nameof(TblAddress.TblPhone))]
        public virtual TblAddress PhoneAddress { get; set; }
        [ForeignKey(nameof(PhoneAreaCodeId))]
        [InverseProperty(nameof(TblAreaCode.TblPhone))]
        public virtual TblAreaCode PhoneAreaCode { get; set; }
        [ForeignKey(nameof(PhoneTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblPhone))]
        public virtual TblCode PhoneTypeCode { get; set; }
    }
}
