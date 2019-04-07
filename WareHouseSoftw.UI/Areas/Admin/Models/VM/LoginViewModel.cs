using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouseSoftw.UI.Areas.Admin.Models.VM
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage ="You Enter Wrong Email"),
            Required(ErrorMessage ="Please enter email addresses"),
            DisplayName("E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter your password")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName{ get; set; }

    }
}