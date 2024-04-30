namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double YearlyProfit = double.Parse(Console.ReadLine());

            double totalYearProfit = deposit * (YearlyProfit / 100);
            double monthlyProfit = totalYearProfit / 12;

            double finalAmount = deposit + months * monthlyProfit;
            Console.WriteLine(finalAmount);
        }
    }
}
