using BEFOYS.DataLayer.Entity.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Panel
{
    public class Tbl_PanelTypeControl
    {
        [Key]
        public int PTC_ID { get; set; }
        public Guid PTC_GUID { get; set; }
        public int PTC_PTID { get; set; }
        public int PTC_ACID { get; set; }
        public DateTime PTC_StartDate { get; set; }
        public DateTime PTC_FinishDate { get; set; }

        [ForeignKey("PTC_PTID")]
        public Tbl_PanelType PanelType { get; set; }

        [ForeignKey("PTC_ACID")]
        public Tbl_AccountControl AccountControl { get; set; }
    }

}
