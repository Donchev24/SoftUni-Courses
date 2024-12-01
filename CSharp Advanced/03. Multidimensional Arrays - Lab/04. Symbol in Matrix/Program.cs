namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            char[,] matrix = new char[dimentions, dimentions];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                char[] data = input.ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());
            bool isFound = false;
            int currentRow = -1;
            int currentCol = -1;

            for (int row = 0;row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbolToFind == matrix[row,col])
                    {
                        isFound = true;
                        currentRow = row;
                        currentCol = col;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine($"({currentRow}, {currentCol})");
            }
            else
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
