using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        class Racer
        {
            public Racer(string name, double distance)
            {
                Name = name;
                Distance = distance;
            }

            public string Name { get; set; }
            public double Distance { get; set; }
        }
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine().Split(", ");

            string input = string.Empty;

            Dictionary<string, Racer> racersList = new Dictionary<string, Racer>();

            while ((input = Console.ReadLine()) != "end of race")
            {
                string patterForName = @"(?<name>[A-Za-z]+)";
                MatchCollection currentMatch = Regex.Matches(input, patterForName);

                string patternForDistance = @"[\d?]";
                MatchCollection currentDistance = Regex.Matches(input, patternForDistance);

                string name = string.Empty;
                double distance = 0;

                foreach (Match match in currentMatch)
                {
                    name += match.Value;
                }

                foreach (Match match in currentDistance)
                {
                    distance += double.Parse(match.Value);
                }

                Racer racer = new Racer(name, distance);

                if (racersList.ContainsKey(name))
                {
                    racersList[name].Distance += distance;
                }

                else if (racers.Contains(name))
                {
                    racersList.Add(name, racer);
                }
            }

            List<Racer> result = racersList.Select(x => x.Value).OrderByDescending(x => x.Distance).Take(3).ToList();

            Console.WriteLine($"1st place: {result[0].Name}");
            Console.WriteLine($"2nd place: {result[1].Name}");
            Console.WriteLine($"3rd place: {result[2].Name}");
        }
    }
}
