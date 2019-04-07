using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouseSoftw.Model.Entity;
using WareHouseSoftw.UI.Areas.Admin.Models.DTO;

namespace WareHouseSoftw.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        // GET: Admin/AppUser
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Role = model.Role;
                user.Gender = model.Gender;
                db.AppUsers.Add(user);
                db.SaveChanges();

                return Redirect("/Admin/AppUser/UserList");               
            }
            else
            {
                return View();
            }         
        }

        public ActionResult UserList()
        {
            List<UserDTO> model = db.AppUsers.Where(x => x.Status == WareHouseSoftw.Model.Enum.Status.Active || x.Status == WareHouseSoftw.Model.Enum.Status.Updated).Select(x => new UserDTO()
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Email = x.Email,
                Password = x.Password,
                Role = x.Role,
                Gender = x.Gender
            }).ToList();
            

            return View(model);

        }

        public ActionResult UpdateUser(int id)
        {
            AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == id);
            UserDTO model = new UserDTO();
            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Password = user.Password;
            model.Email = user.Email;
            model.UserName = user.UserName;
            model.Role = user.Role;
            db.SaveChanges();

            return View(model);                                              
        }

        [HttpPost]
        public ActionResult UpdateUser(UserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == model.ID);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Email = model.Email;
                user.Role = model.Role;
                user.Status = WareHouseSoftw.Model.Enum.Status.Updated;
                user.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/UserList");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == id);
                user.Status = WareHouseSoftw.Model.Enum.Status.Deleted;
                user.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/UserList");

            }
            else
            {
                return Redirect("/Admin/AppUser/UserList");
            }

        }



    }
}