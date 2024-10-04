namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double result = 0;

            Console.WriteLine(RectangleArea(a, b, result));
        }

        static double RectangleArea(double a, double b, double result)
        {
            result = a * b;
            return result;
        }
    }
}