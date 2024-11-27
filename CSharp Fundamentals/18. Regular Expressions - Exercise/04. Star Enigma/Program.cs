using System.Text.RegularExpressions;
using System.Text;

namespace _04._Star_Enigma
{
    internal class Program
    {
        class Planet
        {
            public Planet(string name, string attackType)
            {
                Name = name;
                AttackType = attackType;
            }

            public string Name { get; set; }
            public string AttackType { get; set; }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Planet> attackedPlanetsList = new List<Planet>();
            List<Planet> destroyedPlanetsList = new List<Planet>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                string pattern = @"[SsTtAaRr]";

                MatchCollection messageMatches = Regex.Matches(message, pattern);

                char[] letters = message.ToCharArray();
                StringBuilder encryptedMsg = new StringBuilder();

                for (int j = 0; j < letters.Length; j++)
                {
                    char currentChar = (char)(letters[j] - messageMatches.Count);
                    encryptedMsg.Append(currentChar);
                }

                string decryptingPattern = @"[^\@\-\!\:\>]*\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*:(?<population>\d+)[^\@\-\!\:\>]*!(?<type>D|A)![^\@\-\!\:\>]*->(?<soldiers>\d+)[^\@\-\!\:\>]*";

                MatchCollection decryptedMsg = Regex.Matches(encryptedMsg.ToString(), decryptingPattern);

                if (decryptedMsg.Count > 0)
                {
                    foreach (Match match in decryptedMsg)
                    {
                        string name = match.Groups["planet"].Value;
                        string attackType = match.Groups["type"].Value;
                        Planet planet = new Planet(name, attackType);
                        if (attackType == "A")
                        {
                            attackedPlanetsList.Add(planet);
                        }
                        else
                        {
                            destroyedPlanetsList.Add(planet);
                        }
                    }
                }
            }

            attackedPlanetsList = attackedPlanetsList.OrderBy(p => p.Name).ToList();
            destroyedPlanetsList = destroyedPlanetsList.OrderBy(p => p.Name).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanetsList.Count}");
            foreach (Planet planet in attackedPlanetsList)
            {
                Console.WriteLine($"-> {planet.Name}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanetsList.Count}");
            foreach (Planet planet in destroyedPlanetsList)
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }
    }
}
