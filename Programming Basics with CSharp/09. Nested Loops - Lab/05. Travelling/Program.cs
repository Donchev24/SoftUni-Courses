namespace _05._Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double savedMoney = 0.0;

                while (savedMoney < budget)
                {

                    double newIncome = double.Parse(Console.ReadLine());
                    savedMoney += newIncome;

                    if (savedMoney >= budget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }

                destination = Console.ReadLine();

            }
        }
    }
}
