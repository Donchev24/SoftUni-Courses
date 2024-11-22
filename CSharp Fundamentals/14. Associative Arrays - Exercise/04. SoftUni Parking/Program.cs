namespace _04._SoftUni_Parking
{
    internal class Program
    {
        class User
        {
            public User(string userName)
            {
                UserName = userName;
            }

            public string UserName { get; set; }
            public string LicenseNumber { get; set; }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, User> users = new Dictionary<string, User>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string userName = input[1];

                User user = new User(userName);

                switch (input[0])
                {
                    case "register":
                        if (!users.ContainsKey(userName))
                        {
                            user.LicenseNumber = input[2];
                            users[userName] = user;
                            Console.WriteLine($"{userName} registered {user.LicenseNumber} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {input[2]}");
                        }
                        break;


                    case "unregister":
                        if (users.ContainsKey(userName))
                        {
                            users.Remove(userName);
                            Console.WriteLine($"{userName} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        break;
                }
            }

            foreach (var u in users)
            {
                Console.WriteLine($"{u.Key} => {u.Value.LicenseNumber}");
            }
        }
    }
}
