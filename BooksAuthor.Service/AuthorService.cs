using BooksAuthors.Entity;
using BooksAuthors.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksAuthors.Service
{
    public class AuthorService
    {
        private readonly AuthorsBookContext _context;
        public AuthorService(AuthorsBookContext context)
        {
            _context = context;
        }
        public List<AuthorViewModel> GetAllAuthors()
        {
            List<Author> authors = _context.Authors.ToList();

            List<AuthorViewModel> authorViewModels = authors.Select(x => new AuthorViewModel
            {
                Author_id = x.Author_id,
                Date_Of_Birth = x.Date_Of_Birth,
                First_Name = x.First_Name,
                Last_Name = x.Last_Name
            }).ToList();

            return authorViewModels;
        }

        public void AddAuthor(AuthorViewModel authorViewModel)
        {
            Author author = new Author()
            {
                First_Name = authorViewModel.First_Name,
                Last_Name = authorViewModel.Last_Name,
                Date_Of_Birth = authorViewModel.Date_Of_Birth
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void EditAuthor(int id, AuthorViewModel authorViewModel)
        {
            Author author = _context.Authors.Where(x => x.Author_id == id).FirstOrDefault();

            author.Date_Of_Birth = authorViewModel.Date_Of_Birth;
            author.First_Name = authorViewModel.First_Name;
            author.Last_Name = authorViewModel.Last_Name;
            _context.Authors.Update(author);

            _context.SaveChanges();

        }

        public AuthorViewModel GetAuthor(int id)
        {
            Author author = _context.Authors.Where(x => x.Author_id == id).FirstOrDefault();

            AuthorViewModel authorViewModel = new AuthorViewModel()
            {
                Author_id = author.Author_id,
                Date_Of_Birth = author.Date_Of_Birth,
                First_Name = author.First_Name,
                Last_Name = author.Last_Name
            };

            return authorViewModel;
        }

        public AuthorViewModel GetAuthorWithBooks(int id)
        {
            Author author = _context.Authors.Where(x => x.Author_id == id).FirstOrDefault();

            AuthorViewModel authorViewModel = new AuthorViewModel()
            {
                Author_id = author.Author_id,
                Date_Of_Birth = author.Date_Of_Birth,
                First_Name = author.First_Name,
                Last_Name = author.Last_Name
            };

            List<BookViewModel> books = (from b in _context.Books
                                         join ab in _context.BooksAuthors
                                                 on b.Book_Id equals ab.BookId
                                         where ab.AuthourId == id
                                         select new BookViewModel
                                         {
                                             Book_Id = b.Book_Id,
                                             Book_Title = b.Book_Title
                                         }).ToList();

            authorViewModel.Books = books;

            return authorViewModel;
        }

        public void DeleteAuthor(int id)
        {
            Author author = _context.Authors.Where(x => x.Author_id == id).FirstOrDefault();

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
