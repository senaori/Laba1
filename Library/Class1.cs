using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Book
    {
        public int Id { get; set; } // Уникальный идентификатор
        public string Title { get; set; } // Название книги
        public string Author { get; set; } // Автор
        public int Year { get; set; } // Год издания
    }

}
