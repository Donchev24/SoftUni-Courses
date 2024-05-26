using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string guest = string.Empty;

            HashSet<string> vipGuests = new();
            HashSet<string> regularGuests = new();

            string pattern = @"^[0-9]";

            RegexOptions regex = RegexOptions.Multiline;

            while ((guest = Console.ReadLine()) != "PARTY")
            {
                bool isVip = false;
                foreach (Match m in Regex.Matches(guest, pattern, regex))
                {
                    if (m.Success)
                    {
                        vipGuests.Add(guest);
                        isVip = true;
                    }
                }

                if (isVip == false)
                {
                    regularGuests.Add(guest);
                }
                
            }
            string arrivedGuest = string.Empty;
            while ((arrivedGuest = Console.ReadLine()) != "END")
            {
                if (vipGuests.Contains(arrivedGuest))
                {
                    vipGuests.Remove(arrivedGuest);
                }
                if (regularGuests.Contains(arrivedGuest))
                {
                    regularGuests.Remove(arrivedGuest);
                }
            }

            int notArrivedGuests = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(notArrivedGuests);

            if (vipGuests.Any())
            {
                foreach (var person in vipGuests)
                {
                    Console.WriteLine($"{person}");
                }
            }
            if (regularGuests.Any())
            {
                foreach (var person in regularGuests)
                {
                    Console.WriteLine($"{person}");
                }
            }
            
               
            
        }
    }
}
