namespace _09._Left_and_Right_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
                sum1 += newNum;
            }

            for (int i = 0; i < n; ++i)
            {
                int newNum = int.Parse(Console.ReadLine());
                sum2 += newNum;
            }

            if (sum1 == sum2)
            {
                Console.WriteLine("Yes, sum = " + sum1);
            }
            else
            {
                int diff = Math.Abs(sum1 - sum2);
                Console.WriteLine("No, diff = " + diff);
            }
        }
    }
}
