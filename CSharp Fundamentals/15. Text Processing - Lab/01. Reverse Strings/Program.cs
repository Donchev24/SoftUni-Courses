namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;

            while ((word = Console.ReadLine()) != "end")
            {
                string reversedWord = new string(word.Reverse().ToArray());
                Console.WriteLine($"{word} = {reversedWord}");
            }
        }
    }
}
