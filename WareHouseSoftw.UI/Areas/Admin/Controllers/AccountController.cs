using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WareHouseSoftw.UI.Areas.Admin.Models.VM;

namespace WareHouseSoftw.UI.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Admin/Account
        public ActionResult UserLogin()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AdminHomeIndex", "Home");
            }
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult UserLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.AppUsers.Any(x=> x.Status== WareHouseSoftw.Model.Enum.Status.Active || x.Status==WareHouseSoftw.Model.Enum.Status.Updated))
                {
                    if (db.AppUsers.Any(x=> x.Role==WareHouseSoftw.Model.Enum.Role.Admin))
                    {
                        FormsAuthentication.SetAuthCookie(model.FirstName + "" + model.LastName, true);
                        return RedirectToAction("AdminHomeIndex", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Your Email or Password i s Wrong !";
                    }
                }
                else
                {
                    ViewBag.Message = "Your Email or Password i s Wrong !";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Your Email or Passwor İ  S Wrong";
            }
            return View();
        }
    }
}