namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> kids = new Queue<string>(input);

            int hotPotato = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i <= hotPotato; i++)
                {
                    if (i == hotPotato)
                    {
                        Console.WriteLine($"Removed {kids.Dequeue()}");
                    }
                    else
                    {
                        kids.Enqueue(kids.Dequeue());
                    }
                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
