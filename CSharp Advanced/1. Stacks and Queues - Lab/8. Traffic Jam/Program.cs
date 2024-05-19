
namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountCanPass = int.Parse(Console.ReadLine());

            string input = string.Empty;

            Queue<string> trafficQueue = new Queue<string>();
            int count = 0;

            while ((input = Console.ReadLine()) != "end") 
            {
                if (input == "green")
                {
                    for (int i = 0; i < amountCanPass; i++)
                    {
                        if (trafficQueue.Count > 0)
                        {
                            Console.WriteLine($"{trafficQueue.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    trafficQueue.Enqueue(input);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
            
        }
    }
}
