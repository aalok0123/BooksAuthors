using BooksAuthors.Entity;
using BooksAuthors.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksAuthors.Service
{
    public class BookService
    {
        private readonly AuthorsBookContext _context;

        public BookService(AuthorsBookContext context)
        {
            _context = context;
        }
        public void AddBook(BookViewModel bookViewModel)
        {
            Book book = new Book()
            {
                Book_Title = bookViewModel.Book_Title
            };

            _context.Books.Add(book);

            _context.SaveChanges();

            foreach (int authorId in bookViewModel.SelectedAuthor)
            {
                BooksAuthor booksAuthor = new BooksAuthor()
                {
                    AuthourId = authorId,
                    BookId = book.Book_Id
                };

                _context.SaveChanges();
            }

        }

        public void EditBook(int id, BookViewModel bookViewModel)
        {
            Book book = _context.Books.Where(x => x.Book_Id == id).FirstOrDefault();

            book.Book_Title = bookViewModel.Book_Title;

            _context.Books.Update(book);

            _context.SaveChanges();

            //add
            foreach (int authorId in bookViewModel.SelectedAuthor)
            {
                bool isPresent = _context.BooksAuthors.Where(x => x.BookId == id && x.AuthourId == authorId).Any();

                if (isPresent == false)
                {
                    BooksAuthor booksAuthor = new BooksAuthor()
                    {
                        AuthourId = authorId,
                        BookId = book.Book_Id
                    };

                    _context.SaveChanges();
                }
            }

            //remove
            List<BooksAuthor> booksAuthors = _context.BooksAuthors.Where(x => x.BookId == id).ToList();

            foreach (BooksAuthor bookAuth in booksAuthors)
            {
                bool isPresent = bookViewModel.SelectedAuthor.Where(x => x == bookAuth.AuthourId).Any();

                if (isPresent == false)
                {
                    _context.BooksAuthors.Remove(bookAuth);

                    _context.SaveChanges();
                }
            }

        }

        public List<BookViewModel> GetAllBooks()
        {
            List<Book> books = _context.Books.ToList();


            List<BookViewModel> bookViewModels = books.Select(x => new BookViewModel()
            {
                Book_Id = x.Book_Id,
                Book_Title = x.Book_Title
            }).ToList();

            return bookViewModels;
        }

        public BookViewModel GetBook(int id)
        {
            Book book = _context.Books.Where(x => x.Book_Id == id).FirstOrDefault();

            BookViewModel bookViewModel = new BookViewModel()
            {
                Book_Id = book.Book_Id,
                Book_Title = book.Book_Title,
            };

            List<int> authors = _context.BooksAuthors.Where(x=>x.BookId==id).Select(x=>x.AuthourId).ToList();

            bookViewModel.SelectedAuthor = authors;

            return bookViewModel;
        }

        public void DeleteBook(int id)
        {
            Book book = _context.Books.Where(x => x.Book_Id == id).FirstOrDefault();

            if(book !=null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

    }
}

