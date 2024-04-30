namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double yearTax = double.Parse(Console.ReadLine());

            double shoePrice = yearTax - (yearTax / 100.0 * 40);
            double clothesPrice = shoePrice - (shoePrice / 100.0 * 20);
            double ballPrice = clothesPrice / 100.0 * 25;
            double accessoariesPrice = ballPrice / 100.0 * 20;

            double totalPrice = shoePrice + clothesPrice + ballPrice + accessoariesPrice + yearTax;

            Console.WriteLine(totalPrice);

        }
    }
}
