namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();

            SortedDictionary<string, int> result = new SortedDictionary<string, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                string currentNum = numbers[i];


                if (!result.ContainsKey(currentNum))
                {
                    result.Add(currentNum, 1);
                }
                else
                {
                    result[currentNum] += 1;
                }

            }

            foreach (KeyValuePair<string, int> item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
