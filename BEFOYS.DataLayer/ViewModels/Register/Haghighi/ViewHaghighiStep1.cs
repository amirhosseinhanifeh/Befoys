﻿using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ViewModels.Register.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.Haghighi
{
    public class ViewHaghighiStep1
    {
        public string IdNumber { get; set; }
        public string PersonalCode { get; set; }
        public string BirthDay { get; set; }
        public Enum_Gender Gender { get; set; }
        public ViewAddress[] Addresses { get; set; }
    }
}
