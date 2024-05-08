namespace _04._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;

            string input = Console.ReadLine();
            int steps = 0;
            int totalSteps = 0;

            while (true)
            {

                if (input != "Going home")
                {
                    steps = int.Parse(input);
                    totalSteps += steps;

                    if (totalSteps >= goal)
                    {
                        Console.WriteLine($"Goal reached! Good job!");
                        Console.WriteLine($"{totalSteps - goal} steps over the goal!");
                        break;
                    }
                }

                if (input == "Going home")
                {
                    input = Console.ReadLine();
                    steps = int.Parse(input);
                    totalSteps += steps;

                    if (totalSteps >= goal)
                    {
                        Console.WriteLine($"Goal reached! Good job!");
                        Console.WriteLine($"{totalSteps - goal} steps over the goal!");
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"{goal - totalSteps} more steps to reach goal.");
                        break;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
