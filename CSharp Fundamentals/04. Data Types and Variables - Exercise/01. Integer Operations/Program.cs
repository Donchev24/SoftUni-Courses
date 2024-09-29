namespace _01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fourth = int.Parse(Console.ReadLine());

            int firstExerc = first + second;
            int secondExerc = firstExerc / third;
            int thirdExerc = secondExerc * fourth;

            Console.WriteLine(thirdExerc);
        }
    }
}
