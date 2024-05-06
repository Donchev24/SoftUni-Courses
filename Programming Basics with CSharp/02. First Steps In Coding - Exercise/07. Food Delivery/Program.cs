namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chicken = int.Parse(Console.ReadLine());
            int fish = int.Parse(Console.ReadLine());
            int veg = int.Parse(Console.ReadLine());

            double chickenPrice = chicken * 10.35;
            double fishPrice = fish * 12.40;
            double vegPrice = veg * 8.15;

            double desertPrice = ((chickenPrice + fishPrice + vegPrice) / 100) * 20;
            double totalPrice = chickenPrice + fishPrice + vegPrice + desertPrice + 2.50;

            Console.WriteLine(totalPrice);
        }
    }
}
