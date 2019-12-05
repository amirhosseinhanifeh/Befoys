using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Setting")]
    public partial class TblSetting
    {
        [Column("Setting_ID")]
        public int? SettingId { get; set; }
        [Column("Setting_Guid")]
        public Guid? SettingGuid { get; set; }
    }
}
