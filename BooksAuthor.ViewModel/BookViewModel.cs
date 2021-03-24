using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksAuthors.ViewModel
{
    public class BookViewModel
    {
        [Key]
        public int Book_Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Book_Title { get; set; }

        [DisplayName("Authors")]
        public int AuthorId { get; set; }

        public List<AuthorViewModel> Authors { get; set; }

        public List<int> SelectedAuthor { get; set; }


    }
}
