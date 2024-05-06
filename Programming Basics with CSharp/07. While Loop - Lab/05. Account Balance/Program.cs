namespace _05._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imput = Console.ReadLine();

            double totalMoney = 0;

            while (imput != "NoMoreMoney")
            {
                double currentAmount = double.Parse(imput);

                if (currentAmount < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {currentAmount:F2}");
                totalMoney += currentAmount;




                imput = Console.ReadLine();

            }

            Console.WriteLine($"Total: {totalMoney:F2}");
        }
    }
}
