namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int numCopy = num;
            int result = 0;

            while (numCopy > 0)
            {
                int lastDigitOfNum = numCopy % 10;
                numCopy = numCopy / 10;
                result += lastDigitOfNum;
            }

            Console.WriteLine(result);
        }
    }
}
