namespace _06._Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int f = floors; f >= 1; f--)
            {
                if (f == floors)
                {
                    for (int l = 0; l < rooms; l++)
                    {
                        Console.Write($"L{f}{l} ");
                    }

                    Console.WriteLine();
                }

                else if (f % 2 != 0 && f != floors)
                {
                    for (int a = 0; a < rooms; a++)
                    {
                        Console.Write($"A{f}{a}" + " ");
                    }
                    Console.WriteLine();
                }

                else if (f % 2 == 0 && f != floors)
                {
                    for (int o = 0; o < rooms; o++)
                    {
                        Console.Write($"O{f}{o}" + " ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
