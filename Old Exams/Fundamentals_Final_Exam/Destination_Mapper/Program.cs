using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([=/])([A-Z][a-zA-Z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);

            List<string> destinations = new List<string>();
            int travelPoints = 0;

            foreach (Match match in matches)
            {
                string place = match.Groups[2].Value;
                destinations.Add(place);
                travelPoints += place.Length;
            }

            Console.WriteLine("Destinations: " + (destinations.Count > 0 ? string.Join(", ", destinations) : ""));
            Console.WriteLine("Travel Points: " + travelPoints);
        }
    }
}
