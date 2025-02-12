using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultCategories()
        {
            var values = context.Categories.OrderByDescending(x=>x.CategoryId).Take(6).ToList();

            return PartialView(values);
        }


        public PartialViewResult DefaultBooks()
        {
            var values = context.Books.OrderByDescending(x=>x.BookId).Take(6).ToList();
            return PartialView(values);
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Message model)
        {
            context.Messages.Add(model);
            context.SaveChanges();
            Thread.Sleep(2000);
            return RedirectToAction("Index");
        }
    }
}