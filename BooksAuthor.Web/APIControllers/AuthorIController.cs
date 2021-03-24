using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAuthors.Service;
using BooksAuthors.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAuthor.Web.APIControllers
{

    [ApiController]
    public class AuthorIController : ControllerBase
    {
        private readonly AuthorService _autherService;

        public AuthorIController(AuthorService authorService)
        {
            _autherService = authorService;
        }
        [HttpGet]
        [Route("/api/Authors/{author_id}")]
        public AuthorViewModel Get(int author_id)
        {
            AuthorViewModel authorViewModel = _autherService.GetAuthorWithBooks(author_id);

            return authorViewModel;
        }
    }
}
