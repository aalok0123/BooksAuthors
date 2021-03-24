using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksAuthors.ViewModel
{
    public class AuthorViewModel
    {
        [Key]
        public int Author_id { get; set; }

        [MaxLength(50)]
        [DisplayName("First Name")]
        [Required]
        public string First_Name { get; set; }

        [MaxLength(50)]
        [DisplayName("Last Name")]
        [Required]
        public string Last_Name { get; set; }

        [DisplayName("Date of birth")]
        [Required]
        public DateTime Date_Of_Birth { get; set; }

        public List<BookViewModel> Books { get; set; }
    }
}
