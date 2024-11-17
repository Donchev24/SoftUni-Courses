namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();

            Random random = new Random();

            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = random.Next(list.Count);

                string currentWord = list[i];

                list[i] = list[randomIndex];

                list[randomIndex] = currentWord;
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
