namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int y = 1; y <= 9; y++)
                    {
                        for (int x = 1; x <= 9; x++)
                        {
                            if (number % i == 0 && number % j == 0 && number % y == 0 && number % x == 0)

                                Console.Write($"{i}{j}{y}{x} ");
                        }
                    }
                }
            }
        }
    }
}
