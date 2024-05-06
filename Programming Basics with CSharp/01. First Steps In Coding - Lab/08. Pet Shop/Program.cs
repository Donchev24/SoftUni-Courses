namespace _08._Pet_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dogFoodPacks = double.Parse(Console.ReadLine());
            double catFoodPacks = double.Parse(Console.ReadLine());

            double dogFoodPrice = dogFoodPacks * 2.50;
            double catFoodPrice = catFoodPacks * 4;

            Console.WriteLine(dogFoodPrice + catFoodPrice + " lv.");
        }
    }
}
