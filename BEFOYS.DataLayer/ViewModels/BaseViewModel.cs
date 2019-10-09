using BEFOYS.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels
{
    public class BaseViewModel<T>
    {
        public T Value{ get; set; }
        public Enum_NotificationType NotificationType { get; set; }
        public string Message { get; set; }
    }
}
