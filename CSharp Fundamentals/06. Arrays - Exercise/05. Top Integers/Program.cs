namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int y = 0; y < arr.Length; y++)
            {
                bool isBigger = false;

                for (int i = y + 1; i < arr.Length; i++) 
                {
                    if (arr[y] > arr[i])
                    {
                        isBigger = true;
                    }
                    else
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    Console.Write($"{arr[y]} ");
                }
            }

            Console.Write(arr[arr.Length - 1]);
        }
    }
}
