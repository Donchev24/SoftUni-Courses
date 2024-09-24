namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 1; i <= orders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double price = ((days * capsulesCount) * pricePerCapsule);
                totalPrice += price;

                Console.WriteLine($"The price for the coffee is: ${price:F2}");

                if (i == orders)
                {
                    Console.WriteLine($"Total: ${totalPrice:F2}");
                }
            }
        }
    }
}
