using System.Text;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());
            string result = "";

            Console.Write(StringRepeat(input, repeats, result));
        }

        static string StringRepeat(string input, int repeats, string result)
        {
            StringBuilder TEST = new StringBuilder();
            result = input;

            for (int i = 0; i < repeats; i++)
            {
                TEST.Append(result);
            }

            return TEST.ToString();
        }
    }
}