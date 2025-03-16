namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string result = GetBooksNotReleasedIn(dbContext, 2000);
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
    }
 }


