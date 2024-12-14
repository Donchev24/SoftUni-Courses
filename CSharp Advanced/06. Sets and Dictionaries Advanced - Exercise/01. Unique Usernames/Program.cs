namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new();

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();

                if (!usernames.Contains(username))
                {
                    usernames.Add(username);
                    Console.WriteLine(username);
                }
            }
        }
    }
}
