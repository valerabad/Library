using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        // create connection, default connection             
        DataContext db = new DBContext().db;                                              

        // show all books on start page
        [HttpGet]
        public ActionResult Index()
        {
            List<Book> books = new List<Book>(db.GetTable<Book>());
            return View(books);
        }

        // using technology LINQ to SQL for creating query
        // get all the authors who have written selected book
        [HttpGet]
        public ViewResult ShowAuthorsByBookID(Guid id)
        {
            IEnumerable<Guid> result_id = db.ExecuteQuery<Guid>(
                 @"select BookAuthor.id_author 
                    from BookAuthor 
                    where BookAuthor.id_book = {0}", id);

            List<Author> authorListForSelectBook = new List<Author>();

            foreach (Guid n in result_id)
            {
                Author avtor = db.GetTable<Author>().
                    Where(a => a.Author_Id == n).
                    Select(a => a).
                    First();
                authorListForSelectBook.Add(avtor);
            }
            return View(authorListForSelectBook);
        }

        // using technology LINQ to SQL for creating query
        [HttpGet]
        public ActionResult SortingByTitle()
        {
            List<Book> books = new List<Book>(db.GetTable<Book>().OrderBy(b => b.Title));                        
            return View("Index", books);
        }

        [HttpGet]
        public ActionResult SortingByCount()
        {
            List<Book> books = new List<Book>(db.GetTable<Book>().OrderBy(b => b.quantity));
            return View("Index", books);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            Book book_for_delete = db.GetTable<Book>().Where(b => b.Book_Id == id).Select(b => b).First();        
            db.GetTable<Book>().DeleteOnSubmit(book_for_delete);    
            db.SubmitChanges();          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult ChangeQuantity(Guid id)
        {
            Book book_for_change = db.GetTable<Book>().Where(b => b.Book_Id == id).Select(b => b).First();
            return View(book_for_change);
        }

        [HttpPost]
        public ActionResult ChangeQuantity(Guid id, Book model)
        {
            Book book_for_change = db.GetTable<Book>().Where(b => b.Book_Id == id).Select(b => b).First();
            book_for_change.quantity = model.quantity;            
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        
        public ViewResult AddBook()
        {
            Book newBook = new Book();
            return View(newBook);
        }

        [HttpPost]
        public ActionResult AddBook(Book model)
        {
            db.GetTable<Book>().InsertOnSubmit(model);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }      

        //Auto generated template by Visual Studio 2015
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}