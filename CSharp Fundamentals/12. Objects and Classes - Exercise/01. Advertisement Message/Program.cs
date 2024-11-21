namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] phrase = new string[] 
                {
                    "Excellent product.",
                    "Such a great product.",
                    "I always use that product.",
                    "Best product of its category.",
                    "Exceptional product.",
                    "I can't live without this product."
                };

            string[] events = new string[] 
                {
                    "Now I feel good.",
                    "I have succeeded with this product.",
                    "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.",
                    "Try it yourself, I am very satisfied.",
                    "I feel great!"
                };

            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                int randomPhraseIndex = random.Next(0, phrase.Length);
                string randomPhrase = phrase[randomPhraseIndex];

                int randomEventIndex = random.Next(0, events.Length);
                string randomEvent = events[randomEventIndex];

                int randomAuthorsIndex = random.Next(0, authors.Length);
                string randomAuthor = authors[randomAuthorsIndex];

                int randomCityIndex = random.Next(0, cities.Length);
                string randomCity = cities[randomCityIndex];

                Console.WriteLine($"{randomPhrase} {randomEvent} {randomAuthor} – {randomCity}.");
            }
        }
    }
}
