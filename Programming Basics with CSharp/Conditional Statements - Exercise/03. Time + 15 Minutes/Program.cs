namespace _03._Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalMinutes = (hours * 60) + minutes + 15;

            int newHours = totalMinutes / 60;
            int newMinutes = totalMinutes % 60;

            if (newHours == 24)
            {
                Console.WriteLine($"0:{newMinutes:D2}");
            }
            else
            {
                Console.WriteLine($"{newHours}:{newMinutes:D2}");
            }
        }
    }
}
