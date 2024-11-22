namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> listOfSynonims = new List<string>();
            Dictionary<string, List<string>> wordsAndSynonims = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string currentWord = Console.ReadLine();

                string currentSynonim = Console.ReadLine();

                if (!wordsAndSynonims.ContainsKey(currentWord))
                {
                    wordsAndSynonims[currentWord] = new List<string>();
                }

                wordsAndSynonims[currentWord].Add(currentSynonim);

            }

            foreach (KeyValuePair<string, List<string>> kvp in wordsAndSynonims)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
