using BEFOYS.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register
{
    public class ViewBaseRegister
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="رمز عبور و تکرار رمز عبور مطابقت ندارد")]
        public string ConfirmPassword { get; set; }
        [Required]
        public Enum_UserType Type { get; set; }
    }
}
