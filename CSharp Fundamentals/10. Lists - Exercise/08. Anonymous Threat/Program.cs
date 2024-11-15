namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();
            List<string> input = Console.ReadLine().Split().ToList();

            while (input[0] != "3:1")
            {
                if (input[0] == "merge")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < data.Count)
                    {
                        int lowestIndex = Math.Max(0, int.Parse(input[1]));
                        int highestIndex = Math.Min(data.Count - 1, int.Parse(input[2]));
                        int count = highestIndex - lowestIndex + 1;
                        List<string> mergedElements = data.GetRange(lowestIndex, count);
                        int counter = 0;

                        for (int i = 0; i < mergedElements.Count - 1; i++)
                        {
                            if (counter <= count)
                            {
                                mergedElements[i] += mergedElements[i + 1];
                                mergedElements.RemoveAt(i + 1);
                                i = -1;
                            }
                        }

                        data.RemoveRange(lowestIndex, count);
                        data.InsertRange(lowestIndex, mergedElements);
                    }
                }

                else
                {
                    int partitions = int.Parse(input[2]);
                    int itemLength = data[int.Parse(input[1])].Length;
                    int letters = itemLength / partitions;

                    List<string> devidedElements = new List<string>();

                    var arrayOfTheIndex = data[int.Parse(input[1])].Select(x => new string(x, 1)).ToList(); // a b c d e f g
                    int leftOvers = itemLength % partitions;
                    List<string> leftOverElements = new List<string>();

                    if (itemLength % partitions != 0)
                    {
                        leftOverElements = arrayOfTheIndex.GetRange(arrayOfTheIndex.Count - leftOvers, leftOvers);
                        arrayOfTheIndex.RemoveRange(arrayOfTheIndex.Count - leftOvers, leftOvers);

                        for (int y = 0; y < leftOvers - 1; y++)
                        {
                            leftOverElements[y] += leftOverElements[y + 1];
                            leftOverElements.RemoveAt(y + 1);
                        }
                    }

                    for (int i = 0; i < partitions; i++)
                    {
                        for (int x = 0; x < letters - 1; x++)
                        {
                            arrayOfTheIndex[i] += arrayOfTheIndex[i + 1];
                            arrayOfTheIndex.RemoveAt(i + 1);
                        }
                        if (itemLength % partitions != 0)
                        {
                            if (i == partitions - 1)
                            {
                                arrayOfTheIndex[i] += leftOverElements[0];
                            }
                        }
                    }

                    devidedElements.AddRange(arrayOfTheIndex);

                    data.InsertRange(int.Parse(input[1]), devidedElements);
                    data.RemoveAt(int.Parse(input[1]) + partitions);
                }

                input = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", data));
        }
    }
}
