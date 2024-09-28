namespace _11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double highth = double.Parse(Console.ReadLine());
            double V = (length * width * highth) / 3;

            Console.Write($"Length: Width: Height: Pyramid Volume: {V:f2}");
        }
    }
}
