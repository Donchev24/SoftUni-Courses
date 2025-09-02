namespace World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string travelStops = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] tokens = command.Split(":").ToArray();

                if (tokens[0] == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string text = tokens[2];

                    if (index < travelStops.Length)
                    {
                        travelStops = travelStops.Insert(index, text);
                    }
                }
                else if (tokens[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex < travelStops.Length && endIndex < travelStops.Length)
                    {
                        int count = endIndex - startIndex;
                        travelStops = travelStops.Remove(startIndex, count + 1);
                    }
                }
                else if (tokens[0] == "Switch")
                {
                    string oldText = tokens[1];
                    string newText = tokens[2];

                    if (travelStops.Contains(oldText))
                    {
                        travelStops = travelStops.Replace(oldText, newText);
                    }
                }

                Console.WriteLine(travelStops);
                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {travelStops}");
        }
    }
}
