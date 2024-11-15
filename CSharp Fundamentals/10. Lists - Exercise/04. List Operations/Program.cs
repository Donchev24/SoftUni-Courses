namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            List<string> actions = Console.ReadLine().Split().ToList();

            while (actions[0] != "End")
            {
                string command = actions[0];

                if (command == "Add")
                {
                    list.Add(actions[1]);
                }
                else if (command == "Insert")
                {
                    string item = actions[1];
                    if (int.Parse(actions[2]) >= 0 && int.Parse(actions[2]) < list.Count)
                    {
                        list.Insert(int.Parse(actions[2]), actions[1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "Remove")
                {
                    if (int.Parse(actions[1]) >= 0 && int.Parse(actions[1]) < list.Count)
                    {
                        list.RemoveAt(int.Parse(actions[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

                else if (command == "Shift")
                {
                    if (actions[1] == "left")
                    {
                        int count = int.Parse(actions[2]);
                        count %= list.Count;
                        List<string> leftShifted = list.GetRange(0, count);
                        list.RemoveRange(0, count);
                        list.InsertRange(list.Count, leftShifted);
                    }
                    else
                    {
                        int count = int.Parse(actions[2]);
                        count %= list.Count;
                        List<string> rightShifted = list.GetRange(list.Count - count, count);
                        list.RemoveRange(list.Count - count, count);
                        list.InsertRange(0, rightShifted);
                    }
                }

                actions = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
