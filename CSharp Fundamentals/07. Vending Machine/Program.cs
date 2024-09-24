namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string insert = Console.ReadLine();
            double totalMoney = 0;
            double productPrice = 0;
            string productType = "";
            bool trueProduct = false;

            while (insert != "Start")
            {

                if (insert == "0.1" || insert == "0.2" || insert == "0.5" || insert == "1" || insert == "2")
                {
                    double amount = Double.Parse(insert);
                    totalMoney += amount;
                }

                else
                {
                    Console.WriteLine($"Cannot accept {insert}");
                }

                insert = Console.ReadLine();
            }

            if (insert == "Start")
            {
                string product = Console.ReadLine();

                while (product != "End")
                {
                    switch (product)
                    {
                        case "Nuts": productPrice = 2; productType = "nuts"; trueProduct = true; break;
                        case "Water": productPrice = 0.7; productType = "water"; trueProduct = true; break;
                        case "Crisps": productPrice = 1.5; productType = "crisps"; trueProduct = true; break;
                        case "Soda": productPrice = 0.8; productType = "soda"; trueProduct = true; break;
                        case "Coke": productPrice = 1; productType = "coke"; trueProduct = true; break;

                        default:
                            Console.WriteLine("Invalid product"); break;
                    }
                    if (trueProduct)
                    {
                        if (totalMoney >= productPrice)
                        {
                            Console.WriteLine($"Purchased {productType}");
                            totalMoney -= productPrice;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                    }

                    product = Console.ReadLine();
                }

                if (product == "End")
                {
                    Console.WriteLine($"Change: {totalMoney:F2}");
                }
            }
        }
    }
}
