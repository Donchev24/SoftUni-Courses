namespace _06._World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double ivanTime = distance * timePerMeter;
            double delay = Math.Floor(distance / 15) * 12.5;
            ivanTime = ivanTime + delay;

            if (ivanTime < worldRecord)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {ivanTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {ivanTime - worldRecord:f2} seconds slower.");
            }

        }
    }
}
