namespace _07._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int totalClimbers = 0;
            int peopleInEachGroup;

            int musalaGroup = 0;
            int monblanGroup = 0;
            int kilimajaroGroup = 0;
            int k2Group = 0;
            int everestGroup = 0;

            for (int i = 1; i <= groups; i++)
            {
                peopleInEachGroup = int.Parse(Console.ReadLine());

                if (peopleInEachGroup <= 5)
                {
                    musalaGroup += peopleInEachGroup;
                    totalClimbers += peopleInEachGroup;

                }
                else if (peopleInEachGroup <= 12)
                {
                    monblanGroup += peopleInEachGroup;
                    totalClimbers += peopleInEachGroup;
                }
                else if (peopleInEachGroup <= 25)
                {
                    kilimajaroGroup += peopleInEachGroup;
                    totalClimbers += peopleInEachGroup;
                }
                else if (peopleInEachGroup <= 40)
                {
                    k2Group += peopleInEachGroup;
                    totalClimbers += peopleInEachGroup;
                }
                else
                {
                    everestGroup += peopleInEachGroup;
                    totalClimbers += peopleInEachGroup;
                }
            }


            Console.WriteLine($"{(double)musalaGroup / totalClimbers * 100:F2}%");
            Console.WriteLine($"{(double)monblanGroup / totalClimbers * 100:F2}%");
            Console.WriteLine($"{(double)kilimajaroGroup / totalClimbers * 100:F2}%");
            Console.WriteLine($"{(double)k2Group / totalClimbers * 100:F2}%");
            Console.WriteLine($"{(double)everestGroup / totalClimbers * 100:F2}%");
        }
    }
}
