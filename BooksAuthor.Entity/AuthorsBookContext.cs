
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksAuthors.Entity
{
    public class AuthorsBookContext : DbContext
    {
        public AuthorsBookContext(DbContextOptions<AuthorsBookContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BooksAuthor> BooksAuthors { get; set; }
    }
}
