namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length / 2; i++)
            {
                string firstElement = input[i];
                string lastElement = input[input.Length - 1 - i];

                input[i] = lastElement;
                input[input.Length - 1 - i] = firstElement;
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
