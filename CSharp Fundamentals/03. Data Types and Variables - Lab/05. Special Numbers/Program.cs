namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstDigit = 0; ;
            int lastDigit = 0;
            for (int i = 1; i <= n; i++)
            {
                firstDigit = i % 10;
                lastDigit = i / 10;

                int sum = firstDigit + lastDigit;

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
