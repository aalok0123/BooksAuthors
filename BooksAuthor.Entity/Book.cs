using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksAuthors.Entity
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }

        [MaxLength(100)]
        public string Book_Title { get; set; }

    }
}
