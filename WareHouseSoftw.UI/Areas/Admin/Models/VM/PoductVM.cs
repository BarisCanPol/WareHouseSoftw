using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WareHouseSoftw.Model.Entity;
using WareHouseSoftw.UI.Areas.Admin.Models.DTO;

namespace WareHouseSoftw.UI.Areas.Admin.Models.VM
{
    public class PoductVM
    {
        public PoductVM()
        {
            Categories = new List<Category>();
            Product = new ProductDTO();
        }
        public List<Category> Categories { get; set; }
        public ProductDTO Product { get; set; }
    }
}