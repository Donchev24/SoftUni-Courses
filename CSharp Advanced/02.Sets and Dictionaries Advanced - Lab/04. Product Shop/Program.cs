namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopProducts = new();

            string[] input = Console.ReadLine().Split(", ");     //lidl, juice, 2.30

            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopProducts.ContainsKey(shopName))
                {
                    shopProducts.Add(shopName, new Dictionary<string, double>());
                    shopProducts[shopName].Add(product, price);
                }
                else
                {
                    shopProducts[shopName].Add(product, price);
                }
   

                input = Console.ReadLine().Split(", ");
            }



            foreach ((string shopName, Dictionary<string, double> priceOfProduct) in shopProducts)
            {
                Console.WriteLine($"{shopName}->");

                foreach ((string product, double price) in priceOfProduct)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
                
            }
            
        }
    }
}
