using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Panel
{
    public class Tbl_PanelType
    {
        [Key]
        public int PT_ID { get; set; }
        public Guid PT_GUID { get; set; }
        public string PT_NAME { get; set; }
        public string PT_Display { get; set; }
        public bool PT_ISFree { get; set; }
        public int PT_Price { get; set; }

    }
}
