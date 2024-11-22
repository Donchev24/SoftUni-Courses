namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                if (letter == ' ')
                {
                    continue;
                }

                if (!charCount.ContainsKey(letter))
                {
                    charCount[letter] = 0;
                }

                charCount[letter]++;
            }

            foreach (KeyValuePair<char, int> letter in charCount)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
