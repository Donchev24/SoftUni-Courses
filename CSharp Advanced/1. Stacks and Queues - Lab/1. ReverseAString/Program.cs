namespace _1.ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] textToReverse = input.ToCharArray();

            Stack<char> stack = new(textToReverse);

            Console.Write(string.Join("", stack));
        }
    }
}
