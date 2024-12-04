namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            char[,] board = new char[dimentions, dimentions];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                { 
                    board[row, col] = data[col];
                }    
            }

            bool foundKnight = true;

            int maxCount = 0;
            int knightRow = -1;
            int knightCol = -1;

            int removedKnights = 0;


            while (foundKnight)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentCount = 0;

                        if (board[row, col] == 'K')
                        {

                            if (row - 2 >= 0 && row - 2 < board.GetLength(0)
                                && col - 1 >= 0 && col - 1 < board.GetLength(1)
                                && board[row - 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (row - 2 >= 0 && row - 2 < board.GetLength(0)
                               && col + 1 >= 0 && col + 1 < board.GetLength(1)
                               && board[row - 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (row + 2 >= 0 && row + 2 < board.GetLength(0)
                               && col - 1 >= 0 && col - 1 < board.GetLength(1)
                               && board[row + 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (row + 2 >= 0 && row + 2 < board.GetLength(0)
                              && col + 1 >= 0 && col + 1 < board.GetLength(1)
                              && board[row + 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (row - 1 >= 0 && row - 1 < board.GetLength(0)
                              && col - 2 >= 0 && col - 2 < board.GetLength(1)
                              && board[row - 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (row + 1 >= 0 && row + 1 < board.GetLength(0)
                              && col - 2 >= 0 && col - 2 < board.GetLength(1)
                              && board[row + 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (row - 1 >= 0 && row - 1 < board.GetLength(0)
                             && col + 2 >= 0 && col + 2 < board.GetLength(1)
                             && board[row - 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (row + 1 >= 0 && row + 1 < board.GetLength(0)
                             && col + 2 >= 0 && col + 2 < board.GetLength(1)
                             && board[row + 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxCount > 0)
                {
                    board[knightRow, knightCol] = '0';
                    removedKnights++;
                    maxCount = 0;
                }
                else
                {
                    foundKnight = false;
                }
            }

            Console.WriteLine(removedKnights);
        }
    }
}
