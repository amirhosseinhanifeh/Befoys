using BEFOYS.DataLayer.Entity.Permission;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Permission
{
    public class ViewPermission
    {
        public bool IsFree { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public int? ID { get; set; }
        public ViewPermission(Tbl_Permission model)
        {
            this.DisplayName = model.Permission_Display;
            this.ID = model.Permission_ID;
            this.IsFree = model.Permission_ISFree;
        }
    }
}
