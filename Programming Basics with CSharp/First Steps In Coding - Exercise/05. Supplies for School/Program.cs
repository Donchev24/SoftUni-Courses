namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int chemLitres = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double pensPrice = 5.80 * pens;
            double markersPrice = 7.20 * markers;
            double chemPrice = 1.20 * chemLitres;

            double totalPrice = pensPrice + markersPrice + chemPrice;
            double discountInDecimals = discount / 100.0;
            double finalPrice = totalPrice - discountInDecimals * totalPrice;

            Console.WriteLine(finalPrice);
        }
    }
}
