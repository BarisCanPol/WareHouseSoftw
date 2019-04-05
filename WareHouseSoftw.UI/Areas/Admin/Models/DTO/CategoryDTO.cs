using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouseSoftw.UI.Areas.Admin.Models.DTO
{
    public class CategoryDTO : BaseDTO
    {
        [Required(ErrorMessage="Please Add Category Name")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage ="Please Add Categoty Description")]
        public string Description { get; set; }
    }
}