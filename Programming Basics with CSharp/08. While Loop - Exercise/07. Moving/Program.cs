namespace _07._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int higth = int.Parse(Console.ReadLine());

            int totalSpace = width * length * higth;
            string input = Console.ReadLine();
            int spaceTaken = 0;

            while (input != "Done")
            {
                spaceTaken = int.Parse(input);
                totalSpace -= spaceTaken;

                if (totalSpace <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(totalSpace)} Cubic meters more.");
                    break;
                }



                input = Console.ReadLine();
            }


            if (input == "Done")
            {
                Console.WriteLine($"{totalSpace} Cubic meters left.");
            }
        }
    }
}
