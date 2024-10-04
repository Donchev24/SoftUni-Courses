namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] waggons = new int[n];

            int sum = 0;

            for (int i = 0; i < waggons.Length; i++)
            {
                waggons[i] = int.Parse(Console.ReadLine());
                sum += waggons[i];
            }

            for (int i = 0; i < waggons.Length; i++)
            {
                Console.Write($"{waggons[i]} ");

            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
