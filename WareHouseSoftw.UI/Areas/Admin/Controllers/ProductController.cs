using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouseSoftw.Model.Entity;
using WareHouseSoftw.UI.Areas.Admin.Models.DTO;
using WareHouseSoftw.UI.Areas.Admin.Models.VM;

namespace WareHouseSoftw.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult AddProduct()
        {
            List<Category> model = db.Categories.Where(x => x.Status == WareHouseSoftw.Model.Enum.Status.Active || x.Status == Model.Enum.Status.Updated).ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Prospectus = model.Prospectus;
                product.UnitsInStock = model.UnitsInStock;
                product.UnitPirce = model.UnitPirce;
                product.CategoryID = model.CategoryID;

                db.Products.Add(product);              
                db.SaveChanges();
                return Redirect("/Admin/Product/ProdcutList");
            }
            else
            {
                return View();
            }
           
        }
        public ActionResult ProdcutList()
        {
            List<ProductDTO> model = db.Products.Where(x => x.Status == Model.Enum.Status.Active || x.Status == WareHouseSoftw.Model.Enum.Status.Updated).OrderBy(x => x.CategoryID).Select(x => new ProductDTO
            {
                ID = x.ID,
                ProductName = x.ProductName,
                Prospectus = x.Prospectus,
                UnitPirce = x.UnitPirce,
                UnitsInStock = x.UnitsInStock,
                CategoryID = x.CategoryID,
                Price = x.Price,
                CategoryName=x.Category.CategoryName,
                Quantity=x.Quantity   
                
            }).ToList();

            return View(model);
        }

        public ActionResult UpdateProduct(int id)
        {
            PoductVM model = new PoductVM();
            Product product = db.Products.FirstOrDefault(x => x.ID == id);
            model.Product.ID = product.ID;
            model.Product.ProductName = product.ProductName;
            model.Product.Prospectus = product.Prospectus;
            model.Product.Quantity = product.Quantity;
            model.Product.UnitPirce = product.UnitPirce;
            model.Product.UnitsInStock = product.UnitsInStock;
            model.Product.CategoryName = product.Category.CategoryName;
            model.Product.CategoryID = product.CategoryID;

            
           List<Category> categories = db.Categories.Where(x => x.Status == WareHouseSoftw.Model.Enum.Status.Active || x.Status == WareHouseSoftw.Model.Enum.Status.Updated).ToList();

            model.Categories = categories;

            return View(model);

        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.FirstOrDefault(x => x.ID == model.ID);
                product.ProductName = model.ProductName;
                product.Prospectus = model.Prospectus;
                product.Quantity = model.Quantity;
                product.UnitPirce = model.UnitPirce;
                product.UnitsInStock = model.UnitsInStock;
                product.CategoryID = model.CategoryID;
                product.Category.CategoryName = model.CategoryName;
                product.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Product/ProdcutList");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.FirstOrDefault(x => x.ID == id);
                product.Status = Model.Enum.Status.Deleted;
                product.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Product/ProdcutList");
            }
            else
            {
                return Redirect("/Admin/Product/ProdcutList");
            }
            
        }
    }
}