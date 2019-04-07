using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WareHouseSoftw.Model.Enum;

namespace WareHouseSoftw.UI.Areas.Admin.Models.DTO
{
    public class UserDTO:BaseDTO
    {
        [Required(ErrorMessage ="Please Enter Your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Select a Role")]
        public Role Role { get; set; }
        [Required(ErrorMessage = "Please Select a Gender")]
        public Gender Gender { get; set; }
    }
}