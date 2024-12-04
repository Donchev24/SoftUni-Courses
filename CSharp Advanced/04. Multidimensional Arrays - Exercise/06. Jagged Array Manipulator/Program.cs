namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArr[row] = data;

            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                        jaggedArr[row + 1][col] *= 2;
                    }         
                }
                else
                {
                    for(int col = 0;col < jaggedArr[row].Length;col++)
                    {
                        jaggedArr[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArr[row + 1].Length; col++)
                    {
                        jaggedArr[row + 1][col] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (command[0] == "Add")
                {
                    if (row < 0 || row >= jaggedArr.Length
                        || col < 0 || col >= jaggedArr[row].Length)
                    {
                    }

                    else
                    {
                        jaggedArr[row][col] += value;
                    }
                }

                else
                {
                    if (row < 0 || row >= jaggedArr.Length
                       || col < 0 || col >= jaggedArr[row].Length)
                    {
                    }

                    else
                    {
                        jaggedArr[row][col] -= value;
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                Console.WriteLine($"{string.Join(" ", jaggedArr[row])}");
            }
        }
    }
}
