namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] matrix = new char[rows,cols];

            char[] snakeLetters = Console.ReadLine().ToCharArray();

            Queue<char> snakeMoves = new Queue<char>(snakeLetters);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char currentLetter = snakeMoves.Peek();
                        matrix[row, col] += currentLetter;
                        snakeMoves.Enqueue(snakeMoves.Dequeue());

                    }
                }

                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char currentLetter = snakeMoves.Peek();
                        matrix[row, col] += currentLetter;
                        snakeMoves.Enqueue(snakeMoves.Dequeue());
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
