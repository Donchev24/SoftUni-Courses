namespace _05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int unicodeStart = int.Parse(Console.ReadLine());
            int unicodeEnd = int.Parse(Console.ReadLine());

            for (int i = unicodeStart; i <= unicodeEnd; i++)
            {
                char currentChar = (char)i;
                Console.Write($"{currentChar} ");
            }
        }
    }
}
