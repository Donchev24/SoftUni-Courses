namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digits = new String(input.Where(Char.IsDigit).ToArray());
            char[] removedDigits = digits.ToCharArray();

            for (int i = 0; i < removedDigits.Length; i++)
            {
                int start = input.IndexOf(removedDigits[i]);
                input = input.Remove(start, 1);
            }

            string letters = new String(input.Where(Char.IsLetter).ToArray());
            char[] removedLetters = letters.ToCharArray();

            for (int i = 0; i < removedLetters.Length; i++)
            {
                int start = input.IndexOf(removedLetters[i]);
                input = input.Remove(start, 1);
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(input);
        }
    }
}
