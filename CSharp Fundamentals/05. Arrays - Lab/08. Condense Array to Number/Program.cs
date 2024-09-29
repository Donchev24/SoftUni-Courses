namespace _08._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (numbers.Length < 2)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            int[] condensed = new int[numbers.Length];
            int count = 1;

            while (numbers[1] != 0 || numbers[2] != 0)
            {
                if (numbers[1] == 0 && numbers[2] == 0)
                {
                    break;
                }

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    condensed[i] = numbers[i] + numbers[i + 1];
                }

                for (int i = 0; i < condensed.Length; i++)
                {
                    numbers[i] = condensed[i];
                }

                numbers[numbers.Length - count] = 0;
                condensed[numbers.Length - count] = 0;

                count++;
            }

            Console.WriteLine(numbers[0]);
        }
    }
}
