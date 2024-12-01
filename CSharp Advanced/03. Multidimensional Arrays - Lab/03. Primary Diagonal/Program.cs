using System.Threading.Channels;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimentions,dimentions];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = input[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int i = 0; i < dimentions; i++)
            {
                primaryDiagonalSum += matrix[i,i];
            }

            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
