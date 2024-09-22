namespace _11._Multiplication2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            int counter = 0;

            do
            {
                for (int i = multiplier; ; i++)
                {
                    int result = number * i;

                    if (i > 9)
                    {
                        Console.WriteLine($"{number} X {i} = {result}");
                        break;
                    }

                    else
                    {
                        Console.WriteLine($"{number} X {i} = {result}");
                        counter++;
                    }
                }

            } while (multiplier + counter <= 9);
        }
    }
}
