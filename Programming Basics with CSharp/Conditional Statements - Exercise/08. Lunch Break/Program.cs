namespace _08._Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seriesTime = int.Parse(Console.ReadLine());
            int breakTime = int.Parse(Console.ReadLine());

            double timeForLunch = (double)breakTime * 1 / 8;
            double timeForRelax = (double)breakTime * 1 / 4;
            double timeLeft = breakTime - timeForLunch - timeForRelax;

            if (timeLeft >= seriesTime)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(timeLeft - seriesTime)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(seriesTime - timeLeft)} more minutes.");
            }
        }
    }
}
