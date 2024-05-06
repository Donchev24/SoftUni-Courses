namespace _08._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());

            int totalPoints = 0;

            string result = string.Empty;
            int wins = 0;

            for (int i = 1; i <= tournaments; i++)
            {
                result = Console.ReadLine();

                if (result == "W")
                {
                    totalPoints += 2000;
                    wins++;
                }
                else if (result == "F")
                {
                    totalPoints += 1200;
                }
                else
                    totalPoints += 720;
            }

            totalPoints += startPoints;


            Console.WriteLine($"Final points: {totalPoints}");
            totalPoints -= startPoints;
            Console.WriteLine($"Average points: {totalPoints / tournaments}");
            Console.WriteLine($"{(double)wins / tournaments * 100:F2}%");
        }
    }
}
