using System.Text;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];
                int length = currentWord.Length;

                for (int y = 0; y < length; y++)
                {
                    sb.Append(currentWord);
                }
            }

            Console.Write(sb);
        }
    }
}
