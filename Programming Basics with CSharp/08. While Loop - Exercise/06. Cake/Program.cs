namespace _06._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            int totalCakes = length * width;

            string input = Console.ReadLine();
            int cakesTaken = 0;

            while (input != "STOP")
            {
                cakesTaken = int.Parse(input);

                totalCakes -= cakesTaken;

                if (totalCakes <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(totalCakes)} pieces more.");
                    break;
                }



                input = Console.ReadLine();
            }


            if (input == "STOP")
            {
                Console.WriteLine($"{totalCakes} pieces are left.");

            }
        }
    }
}
