namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numCounts = new();

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (!numCounts.ContainsKey(currentNum))
                {
                    numCounts.Add(currentNum, 0);
                }

                numCounts[currentNum]++;
            }

            foreach (var (k, v) in numCounts)
            {
                if (v % 2 == 0)
                {
                    Console.WriteLine(k);
                }
            }
        }
    }
}
