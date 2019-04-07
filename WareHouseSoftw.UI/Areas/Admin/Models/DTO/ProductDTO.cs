using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WareHouseSoftw.UI.Areas.Admin.Models.DTO
{
    public class ProductDTO:BaseDTO
    {
        [Required(ErrorMessage = "Please Enter a product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please Enter a Prospectus")]
        public string Prospectus { get; set; }
        [Required(ErrorMessage = "Please Enter  UnitPrice")]
        public int? UnitPirce { get; set; }
        [Required(ErrorMessage = "Please Enter Unit Price ")]
        public int? UnitsInStock { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity")]
        public string Quantity { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public decimal? Price { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
    }
}