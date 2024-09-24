namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sum = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = Int32.Parse(number[i].ToString());
                int digitSum = 1;

                for (int d = digit; d > 0; d--)
                {

                    digitSum = digitSum * d;
                }

                sum += digitSum;
            }

            string summary = sum.ToString();

            if (number == summary)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
