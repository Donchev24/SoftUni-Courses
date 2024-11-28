namespace _04._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                else if (input[i] == ')')
                {
                    if (stack.Any())
                    {
                        int startIndex = stack.Pop();
                        string match = input.Substring(startIndex, i - startIndex + 1);
                        Console.WriteLine(match);
                    }
                }

            }
        }
    }
}
