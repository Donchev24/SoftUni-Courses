namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            string input = "R";
            string result = GetBooksByAuthor(dbContext, input);

            Console.WriteLine(result);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            bool isEnumValid = Enum.TryParse(command, true, out AgeRestriction result);

            string[] restrictedBooks = context
                .Books
                .Where(b => b.AgeRestriction == result)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return $"{string.Join(Environment.NewLine, restrictedBooks)}";
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] goldenBooks = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold
                            && b.Copies < 5000)
                .OrderBy (b => b.BookId)
                .Select (b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40m)
                .Select (b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }

            return sb.ToString();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context
                .Books
                .Where(b => b.ReleaseDate.HasValue
                         && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksNotReleasedIn);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var booksByCategory = context
                .Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine,booksByCategory);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime.TryParse(date, out DateTime parsedDate);

            var booksReleasedBefore = context
                .Books
                .Where(b => b.ReleaseDate.HasValue
                         && b.ReleaseDate.Value.CompareTo(parsedDate) < 0)
                .Select(b => new
                {
                    b.Title,
                    b.ReleaseDate,
                    b.EditionType,
                    b.Price
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price.ToString("F2")}");
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var selectedAuthors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach(var author in selectedAuthors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var selectedBooks = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, selectedBooks);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var selectedAuthorsBooks = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    AuthorFirstName =b.Author.FirstName,
                    AuthorLastName = b.Author.LastName,
                   b.Title,
                   b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in selectedAuthorsBooks)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }
    }
 }


