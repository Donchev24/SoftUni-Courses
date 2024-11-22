namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resource = string.Empty;
            Dictionary<string, double> resourceCount = new Dictionary<string, double>();

            while ((resource = Console.ReadLine()) != "stop")
            {
                double quantity = double.Parse(Console.ReadLine());

                if (!resourceCount.ContainsKey(resource))
                {
                    resourceCount.Add(resource, 0);
                }

                resourceCount[resource] += quantity;
            }

            foreach (var r in resourceCount)
            {
                Console.WriteLine($"{r.Key} -> {r.Value}");
            }
        }
    }
}
