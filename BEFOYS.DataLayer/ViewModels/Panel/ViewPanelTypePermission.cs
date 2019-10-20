using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Panel
{
    public class ViewPanelTypePermission
    {
        public Guid? ID { get; set; }
        public Guid[] Permissions { get; set; }
    }
}
