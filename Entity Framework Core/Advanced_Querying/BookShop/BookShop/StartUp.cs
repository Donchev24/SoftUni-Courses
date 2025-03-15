namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            string input = "miNor";

            string result = GetBooksByAgeRestriction(db, input);
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
    }
}


