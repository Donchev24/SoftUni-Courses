namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToList();

            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                string currentWord = words[i];

                if (!result.ContainsKey(currentWord))
                {
                    result.Add(currentWord, 0);
                }
                result[currentWord]++;
            }

            foreach (KeyValuePair<string, int> kvp in result)
            {
                if (kvp.Value % 2 != 0)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }
    }
}
