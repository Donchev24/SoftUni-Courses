namespace _04._Sequence_2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 1;

            while (sum <= number)
            {
                Console.WriteLine(sum);
                sum = sum * 2 + 1;
            }
        }
    }
}
