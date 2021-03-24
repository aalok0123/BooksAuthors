using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAuthors.Entity
{
    public class BooksAuthor
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }

        public int AuthourId { get; set; }
    }
}
