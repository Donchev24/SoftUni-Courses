namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> nameList = new();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                nameList.Add(name);
            }

            foreach (string name in nameList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
