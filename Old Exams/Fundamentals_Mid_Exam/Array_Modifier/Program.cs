using System.Threading.Tasks.Dataflow;

namespace Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "decrease")
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i]--;
                    }
                }
                else
                {
                    string[] tokens = command.Split().ToArray();

                    string action = tokens[0];
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);

                    if (action == "swap")
                    {
                        int temporarySavedValue = values[secondIndex];
                        values[secondIndex] = values[firstIndex];
                        values[firstIndex] = temporarySavedValue;
                    }
                    else if (action == "multiply")
                    {
                        values[firstIndex] *= values[secondIndex];
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", values));
        }
    }
}
