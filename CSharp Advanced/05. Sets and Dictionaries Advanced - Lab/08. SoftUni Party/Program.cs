namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new();
            HashSet<string> regular = new();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (input[0] == '0' || input[0] == '1' || input[0] == '2' || input[0] == '3' ||
                    input[0] == '4' || input[0] == '5' || input[0] == '6' || input[0] == '7' ||
                    input[0] == '8' || input[0] == '9')
                {
                    vip.Add(input);
                }
                else
                {
                    regular.Add(input);
                }

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                if (regular.Contains(input))
                {
                    regular.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);

            if (vip.Any())
             {
                 foreach (string g in vip)
                 {
                     Console.WriteLine(g);
                 }
             }

             if (regular.Any())
             {
                 foreach (string g in regular)
                 {
                     Console.WriteLine(g);
                 }
             }
        }
    }
}
