using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        class Object
        {
            public Object(string name, double price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
        }

        static void Main(string[] args)
        {
            string input = string.Empty;
            double totalPrice = 0;
            List<Object> furnitureList = new List<Object>();

            while ((input = Console.ReadLine()) != "Purchase")
            {
                string pattern = @"\>\>(?<objectName>[A-Za-z]+)\<\<(?<price>[\d+\.\d]+|\d+)!(?<quantity>\d+)";

                MatchCollection properties = Regex.Matches(input, pattern);

                foreach (Match match in properties)
                {
                    string name = match.Groups["objectName"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    Object furniture = new Object(name, price, quantity);

                    furnitureList.Add(furniture);

                    totalPrice += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (Object obj in furnitureList)
            {
                Console.WriteLine($"{obj.Name}");
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
