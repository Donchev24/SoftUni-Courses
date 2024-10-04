namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine()); ;

            for (var step = 0; step < rotations; step++)
            {
                int firstItem = arrOfNumbers[0];
                for (var i = 1; i < arrOfNumbers.Length; i++)
                {
                    arrOfNumbers[i - 1] = arrOfNumbers[i];
                }
                arrOfNumbers[arrOfNumbers.Length - 1] = firstItem;
            }

            for (int i = 0; i < arrOfNumbers.Length; i++)
            {
                Console.Write($"{arrOfNumbers[i]} ");
            }
        }
    }
}
