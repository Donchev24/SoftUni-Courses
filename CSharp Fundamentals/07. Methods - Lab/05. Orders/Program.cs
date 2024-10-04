namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfDrink = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double result = 0;

            OrderPrice(typeOfDrink, quantity, result);

            result = OrderPrice(typeOfDrink, quantity, result);

            Console.WriteLine($"{result:F2}");
        }

        static double OrderPrice(string product, int n, double result)
        {
            result = 0;
            if (product == "coffee")
            {
                result = n * 1.5;
            }
            else if (product == "water")
            {
                result = n * 1.0;
            }
            else if (product == "coke")
            {
                result = n * 1.40;
            }
            else if (product == "snacks")
            {
                result = n * 2.0;
            }
            return result;
        }
    }
}