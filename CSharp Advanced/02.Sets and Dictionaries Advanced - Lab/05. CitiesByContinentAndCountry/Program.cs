using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace _05._CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> citiesByContinentAndCountry = new();

            for (int i = 0; i < numberOfCities; i++)
            {
                string[] dataTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = dataTokens[0];
                string country = dataTokens[1];
                string city = dataTokens[2];

                if (!citiesByContinentAndCountry.ContainsKey(continent))
                {
                    citiesByContinentAndCountry.Add(continent, new Dictionary<string, List<string>>());
                    citiesByContinentAndCountry[continent].Add(country, new List<string>());
                    citiesByContinentAndCountry[continent][country].Add(city);
                }
                else
                {
                    if (!citiesByContinentAndCountry[continent].ContainsKey(country))
                    {
                        citiesByContinentAndCountry[continent].Add(country, new List<string>());

                    }
                    citiesByContinentAndCountry[continent][country].Add(city);
                }
            }

            foreach ((string continent, Dictionary<string, List<string>> countryOfCity) in citiesByContinentAndCountry)
            {
                Console.WriteLine($"{continent}: ");
                foreach ((string country, List<string> city) in countryOfCity)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", city)}");
                }
            }

            
        }
    }
}
