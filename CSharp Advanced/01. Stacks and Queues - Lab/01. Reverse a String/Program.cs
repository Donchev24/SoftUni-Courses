namespace _01._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            Stack<char> reversedStr = new Stack<char>(input);

           

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(reversedStr.Pop());
            }
        }
    }
}
