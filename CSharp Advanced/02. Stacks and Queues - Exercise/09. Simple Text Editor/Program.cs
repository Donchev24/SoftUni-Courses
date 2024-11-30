namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> history = new();

            history.Push(string.Empty);

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string prev = history.Peek();

                if (data[0] == "1")
                {
                    string newText = data[1];
                    history.Push(prev + newText);
                }

                else if (data[0] == "2")
                {
                    int count = int.Parse(data[1]);
                    history.Push(prev.Substring(0, prev.Length - count));
                }

                else if (data[0] == "3")
                {
                    int index = int.Parse(data[1]);
                    Console.WriteLine(prev[index-1]);
                }

                else if (data[0] == "4")
                {
                    history.Pop();
                }
            }
        }
    }
}
