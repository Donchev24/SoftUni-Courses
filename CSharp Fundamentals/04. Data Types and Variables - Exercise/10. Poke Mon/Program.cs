namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            uint count = 0;
            double halfOfN = N * 0.5d;

            while (N >= M)
            {
                if (N == halfOfN && Y != 0)
                {
                    N /= Y;
                }

                if (N >= M)
                {
                    N -= M;
                    count++;
                }
            }

            Console.WriteLine(N);
            Console.WriteLine(count);
        }
    }
}
