namespace _07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrFirst = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arrSecond = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            if (arrFirst.Length != arrSecond.Length)
            {
                return;
            }

            for (int i = 0; i < arrFirst.Length; i++)
            {
                if (arrFirst[i] != arrSecond[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
                sum += arrFirst[i];
            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
