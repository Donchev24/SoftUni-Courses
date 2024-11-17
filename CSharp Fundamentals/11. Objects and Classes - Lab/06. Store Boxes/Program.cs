namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] itemDetails = input.Split();

                Box box = new Box()
                {
                    SerialNumber = itemDetails[0],
                    Quantity = double.Parse(itemDetails[2]),

                    Item = new Item()
                    {
                        Name = itemDetails[1],
                        Price = double.Parse(itemDetails[3])
                    }
                };

                box.BoxPrice = box.Quantity * box.Item.Price;
                boxes.Add(box);
            };

            boxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine($"{box.SerialNumber}{Environment.NewLine}-- {box.Item.Name} - ${box.Item.Price:F2}: {box.Quantity}{Environment.NewLine}-- ${box.BoxPrice:F2}");
            }
        }

        class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        class Box
        {
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public double Quantity { get; set; }
            public double BoxPrice { get; set; }
        }
    }
}