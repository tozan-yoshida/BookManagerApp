﻿using System.ComponentModel.DataAnnotations;

namespace BookManagerApp.Components.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="書籍名を入力してください")]
        public string Title { get; set; }
        [Required(ErrorMessage = "著者を入力してください")]
        public string Author { get; set; }
        [Required(ErrorMessage = "出版社を入力してください")]
        public string Publisher { get; set; }

        public string? RegistDate { get; set; }

        public string? RegistUser { get; set; }

        public string? UpdateDate { get; set; }

        public string? UpdateUser { get; set; }
    }
}
