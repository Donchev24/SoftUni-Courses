namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allowedPasses = int.Parse(Console.ReadLine());

            Queue<string> trafficJam = new Queue<string>();

            int passedCars = 0;

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 1; i <= allowedPasses; i++)
                    {
                        if (trafficJam.Any())
                        {
                            Console.WriteLine($"{trafficJam.Dequeue()} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    trafficJam.Enqueue(command);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
