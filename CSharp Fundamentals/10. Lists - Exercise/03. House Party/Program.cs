namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            List<string> guestsList = new List<string>();

            for (int i = 0; i < guests; i++)
            {
                List<string> names = Console.ReadLine().Split().ToList();

                bool isGoing = guestsList.Contains(names[0]);
                if (isGoing == false)
                {
                    if (names[2] == "not")
                    {
                        Console.WriteLine($"{names[0]} is not in the list!");
                    }
                    else
                    {
                        guestsList.Add(names[0]);
                    }
                }
                else
                {
                    if (names[2] == "not")
                    {
                        guestsList.Remove(names[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{names[0]} is already in the list!");
                    }
                }  
            }

        }
    }
}
