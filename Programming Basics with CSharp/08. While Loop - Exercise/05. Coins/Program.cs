namespace _05._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());

            double totalStotinki = amount * 100;
            int count = 0;

            while (totalStotinki > 0)
            {
                if (totalStotinki >= 200)
                {
                    totalStotinki -= 200;
                    count++;
                }

                else if (totalStotinki >= 100)
                {
                    totalStotinki -= 100;
                    count++;
                }

                else if (totalStotinki >= 50)
                {
                    totalStotinki -= 50;
                    count++;
                }

                else if (totalStotinki >= 20)
                {
                    totalStotinki -= 20;
                    count++;
                }

                else if (totalStotinki >= 10)
                {
                    totalStotinki -= 10;
                    count++;
                }

                else if (totalStotinki >= 5)
                {
                    totalStotinki -= 5;
                    count++;
                }

                else if (totalStotinki >= 2)
                {
                    totalStotinki -= 2;
                    count++;
                }

                else if (totalStotinki >= 1)
                {
                    totalStotinki -= 1;
                    count++;
                }
                else
                    break;
            }

            Console.WriteLine(count);
        }
    }
}
