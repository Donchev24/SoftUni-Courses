namespace _03._Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num;

            int countP1 = 0;
            int countP2 = 0;
            int countP3 = 0;
            int countP4 = 0;
            int countP5 = 0;

            for (int i = 1; i <= n; i++)
            {
                num = int.Parse(Console.ReadLine());

                if (num < 200)
                    countP1++;
                else if (num <= 399)
                    countP2++;
                else if (num <= 599)
                    countP3++;
                else if (num <= 799)
                    countP4++;
                else
                    countP5++;

            }

            Console.WriteLine($"{(double)countP1 / n * 100:F2}%");
            Console.WriteLine($"{(double)countP2 / n * 100:F2}%");
            Console.WriteLine($"{(double)countP3 / n * 100:F2}%");
            Console.WriteLine($"{(double)countP4 / n * 100:F2}%");
            Console.WriteLine($"{(double)countP5 / n * 100:F2}%");
        }
    }
}
