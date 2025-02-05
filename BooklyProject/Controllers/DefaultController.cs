using BooklyProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}