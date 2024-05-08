namespace _01._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int searchedBooks = 0;

            while (true)
            {
                string search = Console.ReadLine();


                if (book == search)
                {
                    Console.WriteLine($"You checked {searchedBooks} books and found it.");
                    break;
                }

                if (search == "No More Books")
                {
                    Console.WriteLine($"The book you search is not here!");
                    Console.WriteLine($"You checked {searchedBooks} books.");
                    break;
                }

                searchedBooks++;
            }
        }
    }
}
