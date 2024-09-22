namespace _04._Back_In_30_Min
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalMinutes = hour * 60 + minutes + 30;
            int finalHour = totalMinutes / 60;
            int finalMinutes = totalMinutes % 60;

            if (finalHour > 23)
            {
                finalHour = 0;
            }

            Console.WriteLine($"{finalHour}:{finalMinutes:D2}");

        }
    }
}
