namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int plaster = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int mixer = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());


            double paintPerCent = paint / 100.0;
            double addedPaint = paintPerCent * 10;


            double plasterPrice = (plaster + 2) * 1.50;
            double paintPrice = (paint + addedPaint) * 14.50;
            double mixerPrice = mixer * 5.00;
            double carryBags = 0.40;

            double totalPrice = plasterPrice + carryBags + mixerPrice + paintPrice;

            double workerPayPerHour = (totalPrice / 100.0) * 30;

            double finalPrice = totalPrice + workerPayPerHour * hours;

            Console.WriteLine(finalPrice);
        }
    }
}
