namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> cityLocations = new();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!cityLocations.ContainsKey(continent))
                {
                    cityLocations.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!cityLocations[continent].ContainsKey(country))
                {
                    cityLocations[continent].Add(country, new List<string>());
                }

                cityLocations[continent][country].Add(city);
            }

            foreach (var (continent, countries) in cityLocations)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, cities) in countries)
                {
                    string stringCities = string.Join(", ", cities);
                    Console.WriteLine($"  {country} -> {stringCities}");
                }
            }
        }
    }
}
