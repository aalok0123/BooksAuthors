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
    public class AuthorController : Controller
    {
        AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            List<AuthorViewModel> authorViewModels = _authorService.GetAllAuthors();
            return View(authorViewModels);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorViewModel authorViewModel)
        {
            try
            {
                _authorService.AddAuthor(authorViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            AuthorViewModel author = _authorService.GetAuthor(id);
            return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorViewModel authorViewModel)
        {
            try
            {
                _authorService.EditAuthor(id, authorViewModel);

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
                _authorService.DeleteAuthor(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
