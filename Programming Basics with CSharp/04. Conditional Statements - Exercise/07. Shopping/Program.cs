namespace _07._Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCardQuantity = int.Parse(Console.ReadLine());
            int cpuQuantity = int.Parse(Console.ReadLine());
            int ramQuantity = int.Parse(Console.ReadLine());

            double videoCardPrice = videoCardQuantity * 250;
            double cpuPrice = (videoCardPrice * 0.35) * cpuQuantity;
            double ramPrice = (videoCardPrice * 0.1) * ramQuantity;

            double totalPrice = videoCardPrice + cpuPrice + ramPrice;

            if (videoCardQuantity > cpuQuantity)
            {
                totalPrice = totalPrice - totalPrice * 0.15;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"You have {budget - totalPrice:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva more!");
            }
        }
    }
}
