namespace _09._Yard_Greening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalSpace = double.Parse(Console.ReadLine());

            double totalPrice = totalSpace * 7.61;

            double discount = totalPrice * 0.18;

            double finalPrice = totalPrice - discount;


            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
