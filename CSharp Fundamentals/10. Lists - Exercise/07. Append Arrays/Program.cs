namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> newList = new List<string>();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                List<string> element = list[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int x = 0; x < element.Count; x++)
                {
                    newList.Add(element[x]);
                }
            }

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
