namespace _07._Area_of_Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();

            if (shape == "square")
            {
                double h = double.Parse(Console.ReadLine());
                double s = h * h;
                Console.WriteLine($"{s:F3}");
            }

            else if (shape == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double s = a * b;
                Console.WriteLine($"{s:f3}");
            }
            else if (shape == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double s = Math.PI * r * r;
                Console.WriteLine($"{s:f3}");
            }
            else if (shape == "triangle")
            {
                double h = double.Parse(Console.ReadLine());
                double hh = double.Parse(Console.ReadLine());
                double s = h * hh / 2;
                Console.WriteLine($"{s:F3}");
            }

        }
    }
}
