namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int tankCapacity = 255;

            for (int i = 0; i < number; i++)
            {
                int inputLitres = int.Parse(Console.ReadLine());

                if (inputLitres <= tankCapacity)
                {
                    tankCapacity -= inputLitres;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(255 - tankCapacity);
        }
    }
}
