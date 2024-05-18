using System.Linq.Expressions;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1+(2-(2+3)*4/(3+1))*5

            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int start = stack.Pop();
                    int end = i;

                    string matchedBrackets = input.Substring(start, end - start + 1);
                    Console.WriteLine(matchedBrackets);
                }

                
            }
        }
    }
}
