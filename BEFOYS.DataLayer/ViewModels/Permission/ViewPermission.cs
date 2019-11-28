
using BEFOYS.DataLayer.Model;
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
        public int Group_ID { get; set; }
        public ViewPermission() { }
        public ViewPermission(TblPermission model)
        {
            this.DisplayName = model.PermissionDisplay;
            this.ID = model.PermissionId;
            this.IsFree = model.PermissionIsFree.GetValueOrDefault();
        }
    }
}
