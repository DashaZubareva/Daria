using DemoMVC.Annotation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DemoMVC.Models
{
    public class Book
    {
        private static Random random = new Random();
       // [ScaffoldColumn(false)]
        public int ID { set; get; }
        [Display(Name = "Название книги")]
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        [DataType(DataType.Text)]
        [CheckLetter(ErrorMessage = "Книга не долджна начитнаться с буквы А")]
        public string Author { set; get; }
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Данное поле не может быть пустым")]
        public string BookName { set; get; }
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Данное поле не может быть пустым")]     
        public decimal Price { get; set; }
        [Display(Name = "Есть в наличии")]
        public bool isPrezent { get; set; }
        public static Book build()
        {
            int index = random.Next(0, 1000);
            return new Book()
            {
                  ID = index,
                  BookName = "Book_" + index,
                  Price = 5 * index,
                  Author = "Autotho_" + index
            };
        }
    }
}