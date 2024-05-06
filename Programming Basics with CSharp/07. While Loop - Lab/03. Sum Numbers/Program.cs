namespace _03._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int imput;
            int sum = 0;

            while (sum < num)
            {
                imput = int.Parse(Console.ReadLine());
                sum += imput;
            }

            Console.WriteLine(sum);
        }
    }
}
