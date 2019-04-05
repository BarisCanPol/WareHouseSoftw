using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseSoftw.Model.Entity
{
   public  class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Prospectus { get; set; }
        public int? UnitPirce { get; set; }
        public int? UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public decimal? Price { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
