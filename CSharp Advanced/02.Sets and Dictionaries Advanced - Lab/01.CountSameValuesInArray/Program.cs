using System.Xml;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> countOfValues = new();
            
            foreach (double value in values)
            {
                if (!countOfValues.ContainsKey(value))
                {
                    countOfValues.Add(value, 0);
                }
                countOfValues[value]++;
            }

           

            foreach (KeyValuePair<double, int> number in countOfValues)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }

           

        }
    }
}
