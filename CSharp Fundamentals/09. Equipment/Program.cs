namespace _09._Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            int totalLightsabers = (int)Math.Ceiling(countOfStudents + countOfStudents * 0.1);

            int beltDiscount = 0;

            if (countOfStudents > 6)
            {
                beltDiscount = countOfStudents / 6;
            }

            int totalBelts = countOfStudents - beltDiscount;

            double totalCost = (priceOfLightsaber * totalLightsabers) + (countOfStudents * priceOfRobe) + (totalBelts * priceOfBelt);

            if (amountOfMoney >= totalCost)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalCost - amountOfMoney:f2}lv more.");
            }
        }
    }
}
