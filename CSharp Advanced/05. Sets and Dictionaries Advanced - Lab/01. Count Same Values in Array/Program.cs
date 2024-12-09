namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> kvp = new();

            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                double currentValue = input[i];

                if (!kvp.ContainsKey(currentValue))
                {
                    kvp.Add(currentValue, 0);
                }

                kvp[currentValue] ++;
            }

            foreach (var value in kvp)
            {
                Console.WriteLine($"{value.Key} - {value.Value} times");
            }
        }
    }
}
