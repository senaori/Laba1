using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Logic
    {
        private List<Book> books = new List<Book>();
        private int nextId = 1;

        /// <summary>
        /// Создаёт новую книгу и присваивает ей уникальный идентификатор.
        /// </summary>
        /// <param name="book">Данные новой книги.</param>
        public void Create(Book book)
        {
            book.Id = nextId++;
            books.Add(book);
        }

        /// <summary>
        /// Возвращает книгу по идентификатору или null, если не найдена.
        /// </summary>
        /// <param name="id">Идентификатор книги.</param>
        /// <returns>Найденная книга или null.</returns>
        public Book Read(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Возвращает полный список книг.
        /// </summary>
        /// <returns>Список всех книг.</returns>
        public List<Book> ReadAll()
        {
            return books;
        }

        /// <summary>
        /// Обновляет данные существующей книги.
        /// </summary>
        /// <param name="id">Идентификатор книги для обновления.</param>
        /// <param name="newBook">Новые данные книги.</param>
        /// <returns>true, если обновлена; иначе false.</returns>
        public bool Update(int id, Book newBook)
        {
            var book = Read(id);
            if (book == null) return false;
            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Year = newBook.Year;
            return true;
        }

        /// <summary>
        /// Удаляет книгу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор удаляемой книги.</param>
        /// <returns>true, если удалена; иначе false.</returns>
        public bool Delete(int id)
        {
            var book = Read(id);
            if (book == null) return false;
            return books.Remove(book);
        }

        /// <summary>
        /// Группирует все книги по авторам.
        /// </summary>
        /// <returns>Словарь: автор → список его книг.</returns>
        public Dictionary<string, List<Book>> GroupByAuthor()
        {
            return books.GroupBy(b => b.Author)
                        .ToDictionary(g => g.Key, g => g.ToList());
        }

        /// <summary>
        /// Находит книги конкретного автора (регистронезависимо).
        /// </summary>
        /// <param name="author">Имя автора для поиска.</param>
        /// <returns>Список найденных книг или пустой список.</returns>
        public List<Book> FindByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author)) return new List<Book>();
            return books
                .Where(b => string.Equals(b.Author?.Trim(), author.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
}

