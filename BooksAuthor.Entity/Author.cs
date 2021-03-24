using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAuthors.Entity
{
    public class Author
    {
        [Key]
        public int Author_id { get; set; }

        [MaxLength(50)]
        public string First_Name { get; set; }

        [MaxLength(50)]
        public string Last_Name { get; set; }

        public DateTime Date_Of_Birth { get; set; }

    }
}
