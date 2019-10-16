using BEFOYS.DataLayer.Entity.Permission;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Permission
{
    public class ViewPermission
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public ViewPermission(Tbl_Permission model)
        {
            this.DisplayName = model.Permission_Display;
            this.Id = model.Permission_GUID;
        }
    }
}
