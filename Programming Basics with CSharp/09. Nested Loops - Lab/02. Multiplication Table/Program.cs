namespace _02._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i1 = 1; i1 <= 10; i1++)
            {

                for (int i2 = 1; i2 <= 10; i2++)
                {
                    int result = i1 * i2;
                    Console.WriteLine($"{i1} * {i2} = {result}");
                }
            }
        }
    }
}
