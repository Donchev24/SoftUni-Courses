namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();

            double studentTickets = 0;
            double standardTickets = 0;
            double kidTickets = 0;
            double totalTickets = 0;

            while (movieName != "Finish")
            {
                double freeSpaces = int.Parse(Console.ReadLine());
                double takenSaces = 0;
                string ticketType = Console.ReadLine();
                double currentMovieTickets = 0;



                while (ticketType != "End")
                {
                    if (ticketType == "student")
                    {
                        studentTickets++;
                        totalTickets++;
                        currentMovieTickets++;
                        takenSaces++;
                    }

                    else if (ticketType == "standard")
                    {
                        standardTickets++;
                        totalTickets++;
                        currentMovieTickets++;
                        takenSaces++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTickets++;
                        totalTickets++;
                        currentMovieTickets++;
                        takenSaces++;
                    }

                    if (freeSpaces == takenSaces)
                    {

                        Console.WriteLine($"{movieName} - {currentMovieTickets * 100.0 / freeSpaces:f2}% full.");
                        break;
                    }
                    ticketType = Console.ReadLine();

                }

                if (ticketType == "End")
                {
                    Console.WriteLine($"{movieName} - {currentMovieTickets * 100.0 / freeSpaces:f2}% full.");
                }
                movieName = Console.ReadLine();
            }

            if (movieName == "Finish")
            {

                Console.WriteLine($"Total tickets: {totalTickets}");
                Console.WriteLine($"{studentTickets * 100.0 / totalTickets:f2}% student tickets.");
                Console.WriteLine($"{standardTickets * 100.0 / totalTickets:F2}% standard tickets.");
                Console.WriteLine($"{kidTickets * 100.0 / totalTickets:f2}% kids tickets.");

            }
        }
    }
}
