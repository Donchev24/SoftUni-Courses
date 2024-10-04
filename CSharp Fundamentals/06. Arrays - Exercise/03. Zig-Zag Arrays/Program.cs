namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] incomingInts = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    firstArr[i] = incomingInts[0];
                    secondArr[i] = incomingInts[1];
                }
                else
                {
                    secondArr[i] = incomingInts[0];
                    firstArr[i] = incomingInts[1];
                }
            }

            for (int i = 0; i < firstArr.Length; i++)
            {
                Console.Write($"{firstArr[i]} ");
            }

            Console.WriteLine();

            for (int i = 0; i < secondArr.Length; i++)
            {
                Console.Write($"{secondArr[i]} ");
            }
        }
    }
}
