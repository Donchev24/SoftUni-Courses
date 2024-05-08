namespace _04._Sum_of_Two_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int low = int.Parse(Console.ReadLine());
            int high = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;

            bool ifFound = false;

            for (int x = low; x <= high; x++)
            {
                for (int y = low; y <= high; y++)
                {
                    int result = x + y;
                    counter++;

                    if (result == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({x} + {y} = {magicNumber})");
                        ifFound = true;
                        break;
                    }

                }

                if (ifFound == true)
                {
                    break;
                }
            }


            if (ifFound == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
