namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using System.Diagnostics.Metrics;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            string input = "12-04-1992";

            string result = GetBooksReleasedBefore(dbContext, input);
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
                .ToArray()
                .OrderByDescending(b => b.ReleaseDate)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price.ToString("F2")} - {book.ReleaseDate}");
            }

            
            return sb.ToString().TrimEnd();
        }
    }
 }


