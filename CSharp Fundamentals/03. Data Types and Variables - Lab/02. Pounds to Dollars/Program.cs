namespace _02._Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float GBP = float.Parse(Console.ReadLine());

            Console.WriteLine($"{GBP * 1.31:F3}");
        }
    }
}
