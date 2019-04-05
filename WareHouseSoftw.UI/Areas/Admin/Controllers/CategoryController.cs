using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouseSoftw.Model.Entity;
using WareHouseSoftw.UI.Areas.Admin.Models.DTO;

namespace WareHouseSoftw.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult AddCategory()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            List<CategoryDTO> model =db.Categories.Where(x => x.Status == WareHouseSoftw.Model.Enum.Status.Active || x.Status == WareHouseSoftw.Model.Enum.Status.Updated).OrderBy(x => x.AddDate).Select(x => new CategoryDTO()
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();  
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
                category.AddDate = DateTime.Now;
                db.Categories.Add(category);
                db.SaveChanges();
                ViewBag.ProcessConditon=1;
                return View();                     //"/Admin/Category/CategoryList"
            }
            else
            {
                ViewBag.ProcessConditon=2;
                return View();
            }
        }
        public ActionResult UpdateCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            CategoryDTO model = new CategoryDTO();
            model.ID = category.ID;
            model.CategoryName = category.CategoryName;
            model.Description = category.Description;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                Category category = db.Categories.FirstOrDefault(x => x.ID == model.ID);
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
                category.Status = WareHouseSoftw.Model.Enum.Status.Updated;
                category.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Category/CategoryList");
            }
            else
            {
                return Redirect("/Admin/Category/CategoryList");
            }
        }

        public ActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                Category category = db.Categories.FirstOrDefault(x => x.ID == id);
                category.Status =WareHouseSoftw.Model.Enum.Status.Deleted;
                category.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Category/CategoryList");
            }
            return Redirect("/Admin/Category/CategoryList");
        }

    }
}