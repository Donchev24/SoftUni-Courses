namespace _03._Sum_Prime_Non_Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int primeSum = 0;
            int nonPrimeSum = 0;

            while (input != "stop")
            {
                int number = int.Parse(input);
                bool isPrime = true;

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();

                    continue;
                }
                for (int i = 2; i < number; i++)
                {
                    int result = number % i;
                    if (result == 0)
                    {
                        isPrime = false;
                        nonPrimeSum += number;
                        break;
                    }

                }
                if (isPrime)
                {
                    primeSum += number;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
