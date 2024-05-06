namespace _02._Half_Sum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int newNum;
            int maxNum = int.MinValue;
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                newNum = int.Parse(Console.ReadLine());
                sum += newNum;
                if (newNum > maxNum)
                    maxNum = newNum;

            }

            sum -= maxNum;

            if (sum == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }

            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum - maxNum)}");
            }
        }
    }
}
