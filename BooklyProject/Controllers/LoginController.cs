
using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BooklyProject.Controllers
{
    public class LoginController : Controller
    {
        BooklyContext context= new BooklyContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin model)
        {
            var admin = context.Admins.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            if(admin == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(admin.UserName, false);
            Session["currentUser"] = admin.UserName;
            return RedirectToAction("Index", "Category");

        }
    }
}