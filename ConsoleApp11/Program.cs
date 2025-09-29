using System;
using Library;

namespace ConsoleApp11
{
    internal class Program
    {
        static Logic logic = new Logic();

        /// <summary>
        /// Точка входа: отображает меню и маршрутизирует команды пользователя.
        /// </summary>
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Создать книгу");
                Console.WriteLine("2. Показать все книги");
                Console.WriteLine("3. Изменить книгу");
                Console.WriteLine("4. Удалить книгу");
                Console.WriteLine("5. Группировать книги по авторам");
                Console.WriteLine("6. Поиск книг по автору");
                Console.WriteLine("0. Выйти");
                Console.Write("Выберите действие: ");

                var key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        CreateBook();
                        break;
                    case "2":
                        ShowAllBooks();
                        break;
                    case "3":
                        UpdateBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
                    case "5":
                        GroupByAuthor();
                        break;
                    case "6":
                        FindByAuthor();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
        }

        /// <summary>
        /// Обрабатывает ввод и создаёт новую книгу в логике.
        /// </summary>
        static void CreateBook()
        {
            Console.Write("Название книги: ");
            string title = Console.ReadLine();

            Console.Write("Автор: ");
            string author = Console.ReadLine();

            Console.Write("Год издания: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Ошибка: неверный ввод года.");
                return;
            }

            logic.Create(new Book { Title = title, Author = author, Year = year });

            Console.WriteLine("Книга успешно добавлена.");
        }

        /// <summary>
        /// Выводит весь список книг на консоль.
        /// </summary>
        static void ShowAllBooks()
        {
            var books = logic.ReadAll();
            if (books.Count == 0)
            {
                Console.WriteLine("Нет книг для отображения.");
                return;
            }

            Console.WriteLine("Список книг:");

            foreach (var b in books)
            {
                Console.WriteLine($"ID: {b.Id}, Название: {b.Title}, Автор: {b.Author}, Год: {b.Year}");
            }
        }

        /// <summary>
        /// Обновляет выбранную книгу по её идентификатору.
        /// </summary>
        static void UpdateBook()
        {
            Console.Write("Введите ID книги для обновления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ошибка: неверный ввод ID.");
                return;
            }

            var book = logic.Read(id);
            if (book == null)
            {
                Console.WriteLine("Книга с таким ID не найдена.");
                return;
            }

            Console.Write($"Новое название (текущее: {book.Title}): ");
            string title = Console.ReadLine();

            Console.Write($"Новый автор (текущий: {book.Author}): ");
            string author = Console.ReadLine();

            Console.Write($"Новый год издания (текущий: {book.Year}): ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Ошибка: неверный ввод года.");
                return;
            }

            logic.Update(id, new Book { Title = title, Author = author, Year = year });
            Console.WriteLine("Книга успешно обновлена.");
        }

        /// <summary>
        /// Удаляет книгу по указанному идентификатору.
        /// </summary>
        static void DeleteBook()
        {
            Console.Write("Введите ID книги для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ошибка: неверный ввод ID.");
                return;
            }

            if (logic.Delete(id))
                Console.WriteLine("Книга успешно удалена.");
            else
                Console.WriteLine("Книга с таким ID не найдена.");
        }

        /// <summary>
        /// Группирует книги по авторам и печатает группы с содержимым.
        /// </summary>
        static void GroupByAuthor()
        {
            var grouped = logic.GroupByAuthor();

            if (grouped.Count == 0)
            {
                Console.WriteLine("Нет книг для группировки.");
                return;
            }

            foreach (var kvp in grouped)
            {
                Console.WriteLine($"Автор: {kvp.Key}");
                foreach (var book in kvp.Value)
                {
                    Console.WriteLine($"  ID: {book.Id}, Название: {book.Title}, Год: {book.Year}");
                }
            }
        }

        /// <summary>
        /// Находит и выводит книги конкретного автора.
        /// </summary>
        static void FindByAuthor()
        {
            Console.Write("Введите автора: ");
            string author = Console.ReadLine();

            var found = logic.FindByAuthor(author);
            if (found.Count == 0)
            {
                Console.WriteLine("Книги не найдены.");
                return;
            }

            foreach (var b in found)
            {
                Console.WriteLine($"ID: {b.Id}, Название: {b.Title}, Автор: {b.Author}, Год: {b.Year}");
            }
        }
    }
}
