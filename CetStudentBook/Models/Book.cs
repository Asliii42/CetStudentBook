using System;
using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models
{



    public class Book
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunlu")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Kitap adı 2-200 karakter olmalı")]
        public string Name { get; set; } = "";

        [Required (ErrorMessage = "Yazar zorunlu")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Yazar 2-200 karakter olmalı")]
        public string Author { get; set; } = "";
        
        [Required(ErrorMessage = "Tarih zorunlu")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        
        [Required (ErrorMessage = "Sayfa sayısı zorunlu")]
        [Range(1, 10000, ErrorMessage = "Sayfa sayısı 1-10000 arası olmalıdır")]
        public int PageCount { get; set; }
        
        [Required(ErrorMessage = "İkinci el seçimi zorunlu")]
        public bool IsSecondHand {get; set;}
        

    }
}