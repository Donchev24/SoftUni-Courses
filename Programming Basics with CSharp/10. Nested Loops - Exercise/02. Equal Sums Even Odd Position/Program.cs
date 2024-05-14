namespace _02._Equal_Sums_Even_Odd_Position
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {

                int odds = 0;
                int evens = 0;

                string currentNum = i.ToString();
                for (int x = 0; x < currentNum.Length; x++)
                {
                    if (x % 2 == 0)
                    {
                        evens += currentNum[x];
                    }
                    else if (x % 2 != 0)
                    {
                        odds += currentNum[x];
                    }
                }
                if (odds == evens)
                {
                    Console.Write($"{currentNum} ");
                }
            }
        }
    }
}
