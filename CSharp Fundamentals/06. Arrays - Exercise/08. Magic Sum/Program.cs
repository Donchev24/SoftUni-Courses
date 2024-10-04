namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();    //1 7 6 2 19 23

            int number = int.Parse(Console.ReadLine());

            for (int mainIndex = 0; mainIndex < arr.Length; mainIndex++)
            {
                for (int i = mainIndex + 1; i < arr.Length; i++)
                {
                    if (arr[mainIndex] + arr[i] == number)
                    {
                        Console.WriteLine($"{arr[mainIndex]} {arr[i]}");

                        break;
                    }
                }
            }
        }
    }
}
