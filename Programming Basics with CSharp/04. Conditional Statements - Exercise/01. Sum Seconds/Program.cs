namespace _01._Sum_Seconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstPlayer = int.Parse(Console.ReadLine());
            int secondPlayer = int.Parse(Console.ReadLine());
            int thirdPlayer = int.Parse(Console.ReadLine());

            int totalTimeInSeconds = firstPlayer + secondPlayer + thirdPlayer;
            int totalMinutes = totalTimeInSeconds / 60;
            int totalSeconds = totalTimeInSeconds % 60;

            Console.WriteLine($"{totalMinutes}:{totalSeconds:D2}");
        }
    }
}
