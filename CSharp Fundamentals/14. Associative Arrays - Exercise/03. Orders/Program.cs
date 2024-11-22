namespace _03._Orders
{
    class Product
    {
        public Product(string name, decimal price, decimal quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
    }
     
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productArgs = input.Split();
                string name = productArgs[0];
                decimal price = decimal.Parse(productArgs[1]);
                decimal quantity = decimal.Parse(productArgs[2]);

                Product product = new Product(name, price, quantity);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, product);
                }
                else
                {
                    products[name].Price = price;
                    products[name].Quantity += quantity;
                }
            }
            decimal totalPrice = 0;

            foreach (var P in products)
            {
                Console.WriteLine($"{P.Key} -> {P.Value.Price * P.Value.Quantity:F2}");
            }
        }
    }
}
