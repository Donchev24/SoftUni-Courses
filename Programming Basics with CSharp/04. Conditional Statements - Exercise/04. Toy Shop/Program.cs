namespace _04._Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesQuantity = int.Parse(Console.ReadLine());
            int dollsQuantity = int.Parse(Console.ReadLine());
            int bearsQuantity = int.Parse(Console.ReadLine());
            int minionsQuantity = int.Parse(Console.ReadLine());
            int trucksQuantity = int.Parse(Console.ReadLine());

            double totalPrice = (puzzlesQuantity * 2.60) + (dollsQuantity * 3) + (bearsQuantity * 4.10) + (minionsQuantity * 8.20) + (trucksQuantity * 2);
            int totalQuantity = puzzlesQuantity + dollsQuantity + bearsQuantity + minionsQuantity + trucksQuantity;

            if (totalQuantity >= 50)
            {
                totalPrice = totalPrice - totalPrice * 0.25;
            }

            totalPrice = totalPrice - totalPrice * 0.1;

            if (totalPrice >= tripPrice)
            {

                Console.WriteLine($"Yes! {totalPrice - tripPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(totalPrice - tripPrice):F2} lv needed.");
            }
        }
    }
}
