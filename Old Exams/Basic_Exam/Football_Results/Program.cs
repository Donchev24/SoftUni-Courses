namespace Football_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = 3;
            int cols = 2;

            int[,] scores = new int[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                int[] result = Console.ReadLine().Split(":").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    scores[row, col] = result[col];
                }
            }

            int wins = 0;
            int loses = 0;
            int draws = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < 1; col++)
                {
                    if (scores[row, col] > scores[row, col + 1])
                    {
                        wins++;
                    }
                    else if (scores[row, col] < scores[row, col + 1])
                    {
                        loses++;
                    }
                    else
                    {
                        draws++;
                    }
                }
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");
        }
    }
}
