namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double pricePerPerson = 0;

            switch (dayOfWeek)
            {
                case "Friday":
                    if (typeOfGroup == "Students")
                    {
                        pricePerPerson = 8.45;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        pricePerPerson = 10.90;
                    }
                    else
                    {
                        pricePerPerson = 15;
                    }
                    break;
                case "Saturday":
                    if (typeOfGroup == "Students")
                    {
                        pricePerPerson = 9.80;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        pricePerPerson = 15.60;
                    }
                    else
                    {
                        pricePerPerson = 20;
                    }
                    break;
                case "Sunday":
                    if (typeOfGroup == "Students")
                    {
                        pricePerPerson = 10.46;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        pricePerPerson = 16.00;
                    }
                    else
                    {
                        pricePerPerson = 22.50;
                    }
                    break;
                default:
                    break;
            }

            double totalPrice = countOfPeople * pricePerPerson;

            if (typeOfGroup == "Students" && countOfPeople >= 30)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (typeOfGroup == "Business" && countOfPeople >= 100)
            {
                totalPrice -= 10 * pricePerPerson;
            }
            else if (typeOfGroup == "Regular" && countOfPeople >= 10 && countOfPeople <= 20)
            {
                totalPrice -= totalPrice * 0.05;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
