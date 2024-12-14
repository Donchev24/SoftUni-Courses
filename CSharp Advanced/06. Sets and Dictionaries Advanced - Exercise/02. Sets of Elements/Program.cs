namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nmLengths = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = nmLengths[0];
            int m = nmLengths[1];

            HashSet<int> nSet = new();
            HashSet<int> mSet = new();

            for (int i = 1; i <= n + m; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (i <= n)
                {
                    nSet.Add(currentNum);
                }
                else
                {
                    mSet.Add(currentNum);
                }
            }

            foreach (int i in nSet)
            {
                if (mSet.Contains(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
