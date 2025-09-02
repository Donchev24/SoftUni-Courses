using System.Linq.Expressions;

namespace World_Snooker_Championship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tournamentStage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());
            char photoChoice = char.Parse(Console.ReadLine());

            double singleTicketPrice = 0;

            switch (ticketType)
            {
                case "Standard":
                    if (tournamentStage == "Quarter final")
                    {
                        singleTicketPrice = 55.50;
                    }
                    else if (tournamentStage == "Semi final")
                    {
                        singleTicketPrice = 75.88;
                    }
                    else if(tournamentStage == "Final")
                    {
                        singleTicketPrice = 110.10;
                    }
                    break;
                case "Premium":
                    if (tournamentStage == "Quarter final")
                    {
                        singleTicketPrice = 105.20;
                    }
                    else if (tournamentStage == "Semi final")
                    {
                        singleTicketPrice = 125.22;
                    }
                    else if (tournamentStage == "Final")
                    {
                        singleTicketPrice = 160.66;
                    }
                    break;
                case "VIP":
                    if (tournamentStage == "Quarter final")
                    {
                        singleTicketPrice = 118.90;
                    }
                    else if (tournamentStage == "Semi final")
                    {
                        singleTicketPrice = 300.40;
                    }
                    else if (tournamentStage == "Final")
                    {
                        singleTicketPrice = 400;
                    }
                    break;
            }

            double totalTicketsPrice = singleTicketPrice * ticketsCount;
            bool isOver4000 = false;
            
            if(totalTicketsPrice > 4000)
            {
                totalTicketsPrice -= totalTicketsPrice * 0.25;
                isOver4000 = true;
            }
            else if (totalTicketsPrice > 2500)
            {
                totalTicketsPrice -= totalTicketsPrice * 0.1;
            }

            if (isOver4000 == false && photoChoice == 'Y')
            {
                totalTicketsPrice += ticketsCount * 40;
            }

            Console.WriteLine($"{totalTicketsPrice:F2}");
        }
    }
}
