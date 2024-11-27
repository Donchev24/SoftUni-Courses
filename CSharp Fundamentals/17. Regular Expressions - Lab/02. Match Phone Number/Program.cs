using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            string input = Console.ReadLine();

            MatchCollection result = Regex.Matches(input, pattern);

            string[] readyResult = result.Cast<Match>().Select(x => x.Value).ToArray();

            for (int i = 0; i < readyResult.Length; i++)
            {
                if (i <= readyResult.Length - 2)
                {
                    Console.Write($"{readyResult[i]}, ");
                }
                else
                {
                    Console.Write($"{readyResult[i]}");
                }
            }
        }
    }
}
