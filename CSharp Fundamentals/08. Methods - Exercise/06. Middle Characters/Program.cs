namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            int a = str.Length % 2;
            char middleChar = str[str.Length / 2];
            Console.WriteLine(middleChar);
        }
    }
}
