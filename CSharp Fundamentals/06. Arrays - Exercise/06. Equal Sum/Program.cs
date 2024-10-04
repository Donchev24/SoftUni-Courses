namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int mainIndex = 0; mainIndex < nums.Length; mainIndex++) 
            {
                int backwardsSum = 0;
                int forwardSum = 0;

                for (int backwards = nums.Length - 1; backwards > mainIndex; backwards--)
                {
                    backwardsSum += nums[backwards];
                }

                for (int forward = 0; forward < mainIndex; forward++)
                {
                    forwardSum += nums[forward];
                }


                if (forwardSum == backwardsSum)
                {
                    Console.WriteLine(mainIndex);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
