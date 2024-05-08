namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tripCost = double.Parse(Console.ReadLine());
            double startAmount = double.Parse(Console.ReadLine());

            int days = 0;
            int spendDays = 0;
            double totalMoney = startAmount;

            while (totalMoney < tripCost)
            {


                string action = Console.ReadLine();
                double amount = double.Parse(Console.ReadLine());

                days++;

                if (action == "spend")
                {
                    spendDays++;

                    if (spendDays == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(days);
                        break;
                    }

                    if (amount >= totalMoney)
                    {
                        totalMoney = 0;
                        continue;
                    }

                    totalMoney -= amount;

                }

                if (action == "save")
                {
                    totalMoney += amount;
                    spendDays = 0;
                }




            }

            if (totalMoney >= tripCost)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
