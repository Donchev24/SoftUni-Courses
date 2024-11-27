using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Order
    {
        public Order(string customerName, string product, int count, double price)
        {
            CustomerName = customerName;
            Product = product;
            Count = count;
            Price = price;
        }

        public string CustomerName { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public double TotalIncome { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Order> orders = new List<Order>();
            double totalIncome = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"%(?<name>[A-Z][a-z]+)%[^\|\$\%\.]*\<(?<product>\w+)\>[^\|\$\%\.]*\|(?<count>\d+)\|[^\|\$\%\.]*?(?<price>\d+\.\d+|\d+)\$[^\|\$\%\.]*";
                MatchCollection orderArgs = Regex.Matches(input, pattern);

                string customerName = string.Empty;
                string product = string.Empty;
                int count = 0;
                double price = 0;

                foreach (Match match in orderArgs)
                {
                    customerName = match.Groups["name"].Value;
                    product = match.Groups["product"].Value;
                    count = int.Parse(match.Groups["count"].Value);
                    price = double.Parse(match.Groups["price"].Value);

                    Order order = new Order(customerName, product, count, price);
                    orders.Add(order);
                    order.TotalPrice = price * count;
                    totalIncome += order.TotalPrice;
                }
            }

            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.CustomerName}: {order.Product} - {order.TotalPrice:F2}");
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
