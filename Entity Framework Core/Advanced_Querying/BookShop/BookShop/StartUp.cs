namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string result = GetGoldenBooks(dbContext);
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
    }
 }


