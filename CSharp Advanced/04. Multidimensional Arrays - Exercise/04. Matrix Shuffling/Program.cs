namespace _04._Matrix_Shuffling
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] != "swap" || command.Length < 5 || command.Length > 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                if   (row1 < 0 || row1 >= matrix.GetLength(0) 
                   || row2 < 0 || row2 >= matrix.GetLength(0)
                   || col1 < 0 || col1 >= matrix.GetLength(1)
                   || col2 < 0 || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                string tempValue = matrix[row1, col1];

                matrix[row1,col1] = matrix[row2,col2];
                matrix[row2, col2] = tempValue;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row,col]} ");
                    }

                    Console.WriteLine();
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

