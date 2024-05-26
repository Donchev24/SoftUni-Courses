using System.Data;

namespace _02._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimmentions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimmentions[0];
            int cols = dimmentions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colValues[col];           
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int rowSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    rowSum+= matrix[row, col];
                }
                Console.WriteLine(rowSum);

            }
        }
    }
}
