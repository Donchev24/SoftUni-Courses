namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimentions, dimentions];

            for (int row = 0; row < dimentions; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < dimentions; col++)
                {
                    matrix[row,col] = data[col];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0;i < dimentions; i++)
            {
                primarySum += matrix[i,i];
            }

           
            for (int i = 0; i < dimentions; i++)
            {
                secondarySum += matrix[i, dimentions - 1 -i];
            }

            Console.WriteLine($"{Math.Abs(primarySum - secondarySum)}");
        }
    }
}
