namespace Basic_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double singleRocketPrice = double.Parse(Console.ReadLine());
            int rocketsCount = int.Parse(Console.ReadLine());
            int shoesCount = int.Parse(Console.ReadLine());

            double singleShoesPrice = singleRocketPrice / 6;

            double totalRocketsPrice = singleRocketPrice * rocketsCount;
            double totalShoesPrice = singleShoesPrice * shoesCount;
            double otherGearPrice = (totalRocketsPrice + totalShoesPrice) * 0.2;
            
            double totalPrice = totalRocketsPrice + totalShoesPrice + otherGearPrice;

            double oneEihthOfPrice = totalPrice / 8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(oneEihthOfPrice)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(oneEihthOfPrice * 7)}");
        }
    }
}
