namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] text = input.ToCharArray();

            Dictionary<char, int> symbolCount = new();

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (!symbolCount.ContainsKey(symbol))
                {
                    symbolCount.Add(symbol, 0);
                }

                symbolCount[symbol]++;
            }

            foreach (var (symbol, count) in symbolCount.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
