using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_AreaCode")]
    public partial class TblAreaCode
    {
        public TblAreaCode()
        {
            TblPhone = new HashSet<TblPhone>();
        }

        [Key]
        [Column("AC_ID")]
        public int AcId { get; set; }
        [Column("AC_Guid")]
        public Guid AcGuid { get; set; }
        [Column("AC_CityID")]
        public int AcCityId { get; set; }
        [Column("AC_Code")]
        public int AcCode { get; set; }

        [ForeignKey(nameof(AcCityId))]
        [InverseProperty(nameof(TblCity.TblAreaCode))]
        public virtual TblCity AcCity { get; set; }
        [InverseProperty("PhoneAreaCode")]
        public virtual ICollection<TblPhone> TblPhone { get; set; }
    }
}
