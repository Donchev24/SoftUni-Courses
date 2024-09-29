namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int source = int.Parse(Console.ReadLine());

            int sourceCopy = source;
            int extratedSpice = 0;
            int days = 0;

            while (sourceCopy >= 100)
            {
                days++;
                extratedSpice = extratedSpice + sourceCopy - 26;
                sourceCopy -= 10;
            }

            if (extratedSpice >= 26)
            {
                extratedSpice -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(extratedSpice);
        }
    }
}
