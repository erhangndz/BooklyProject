using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
   
    public class BooksController : Controller
    {
       BooklyContext context = new BooklyContext();
        public ActionResult Index(string searchText)
        {

            List<Book> values;

            if(searchText!= null)
            {
                values = context.Books.Where(x => x.BookName.Contains(searchText)).ToList();
                return View(values);
            }

            values = context.Books.ToList();
            return View(values);
        }
    }
}