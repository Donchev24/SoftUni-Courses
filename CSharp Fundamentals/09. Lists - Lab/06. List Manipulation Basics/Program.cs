namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> newCommand = Console.ReadLine().Split().ToList();

            while (newCommand[0] != "end")
            {
                if (newCommand[0] == "Add")
                {
                    numbers.Add(int.Parse(newCommand[1]));
                }
                else if (newCommand[0] == "Remove")
                {
                    numbers.Remove(int.Parse(newCommand[1]));
                }
                else if (newCommand[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(newCommand[1]));
                }
                else
                {
                    numbers.Insert(int.Parse(newCommand[2]), int.Parse(newCommand[1]));
                }

                newCommand = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
