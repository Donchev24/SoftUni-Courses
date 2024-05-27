namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] value = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                    jaggedArr[row] = value;              
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                int rowCommand = int.Parse(tokens[1]);
                int colCommand = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (rowCommand < 0 || rowCommand >= rowsCount || colCommand < 0 || colCommand >= jaggedArr[rowCommand].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (action)
                {
                    case "Add":
                        jaggedArr[rowCommand][colCommand] += value;
                        break;

                    case "Subtract":
                        jaggedArr[rowCommand][colCommand] -= value;
                        break;
                }

            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
