namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> list = new Queue<string>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (list.Any())
                    {
                        Console.WriteLine(list.Dequeue());
                    }
                }
                else
                {
                    list.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{list.Count} people remaining.");
        }
    }
}
