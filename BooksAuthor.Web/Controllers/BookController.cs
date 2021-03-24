using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAuthors.Service;
using BooksAuthors.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAuthors.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;
        public BookController(BookService bookService, AuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }
        // GET: BookController
        public ActionResult Index()
        {
            List<BookViewModel> books = _bookService.GetAllBooks();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            BookViewModel bookViewModel = new BookViewModel();
            bookViewModel.Authors = _authorService.GetAllAuthors();
            return View(bookViewModel);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel book)
        {
            try
            {
                _bookService.AddBook(book);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            BookViewModel book = _bookService.GetBook(id);
            book.Authors = _authorService.GetAllAuthors();
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookViewModel bookViewModel)
        {
            try
            {
                _bookService.EditBook(id, bookViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _bookService.DeleteBook(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
