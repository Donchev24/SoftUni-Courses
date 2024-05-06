namespace _04._Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int savings = 0;
            int toyCount = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savings += i * 5 - 1;
                }
                else
                {
                    toyCount++;
                }
            }

            int totalMoney = savings + toyCount * toyPrice;

            if (totalMoney >= washingMachine)
            {
                Console.WriteLine($"Yes! {totalMoney - washingMachine:F2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(washingMachine - totalMoney):F2}");
            }
        }
    }
}
