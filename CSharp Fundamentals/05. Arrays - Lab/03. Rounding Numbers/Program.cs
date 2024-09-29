namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arrOfNums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            int[] roundedNums = new int[arrOfNums.Length];

            for (int i = 0; i < arrOfNums.Length; i++)
            {
                roundedNums[i] = (int)Math.Round(arrOfNums[i], MidpointRounding.AwayFromZero);
            }

            for (int i = 0; i < arrOfNums.Length; i++)
            {
                Console.WriteLine($"{arrOfNums[i]} => {roundedNums[i]}");
            }
        }
    }
}
