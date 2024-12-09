namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopProducts = new();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopProducts.ContainsKey(shopName))
                {
                    shopProducts.Add(shopName, new Dictionary<string, double>());
                }

                shopProducts[shopName].Add(product, price);

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var (shop, productPrice) in shopProducts)
            {
                Console.WriteLine($"{shop}->");

                foreach (var (product, price) in productPrice)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }        
    }
}
