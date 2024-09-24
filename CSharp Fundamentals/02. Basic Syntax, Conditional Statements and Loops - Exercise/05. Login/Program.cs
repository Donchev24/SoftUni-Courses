namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            int length = username.Length;

            string password = "";
            int count = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            string attempt = Console.ReadLine();

            while (attempt != password)
            {
                count++;
                if (count == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");

                attempt = Console.ReadLine();
            }

            if (attempt == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
