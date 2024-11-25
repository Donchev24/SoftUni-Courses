namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string currentWord = bannedWords[i];
                int length = currentWord.Length;
                text = text.Replace(currentWord, new string('*', length));
            }

            Console.WriteLine(text);
        }
    }
}
