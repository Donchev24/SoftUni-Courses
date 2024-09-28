namespace _04._Centuries_to_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal centures = decimal.Parse(Console.ReadLine());

            decimal years = centures * 100;
            decimal days = Math.Round(years * (decimal)365.2422);
            ulong hours = (ulong)days * 24;
            ulong minutes = ((ulong)hours * 60);

            Console.WriteLine($"{centures} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
