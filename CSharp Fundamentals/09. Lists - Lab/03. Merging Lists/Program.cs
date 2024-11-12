namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mergedLists = new List<int>();

            double greaterValue = double.MinValue;

            if (firstList.Count >= secondList.Count)
            {
                greaterValue = firstList.Count;
            }
            else
            {
                greaterValue = secondList.Count;
            }

            for (int i = 0; i < greaterValue; i++)
            {
                if ((firstList.Count - 1) >= i)
                {
                    mergedLists.Add(firstList[i]);
                }
                if (secondList.Count - 1 >= i)
                {
                    mergedLists.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedLists));
        }
    }
}
