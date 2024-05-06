using System.Threading.Tasks;

namespace _09._Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int higth = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            int totalSize = length * width * higth;
            double totalSizeInLitres = totalSize * 0.001;
            double spaceTaken = percentage * 0.01;
            Console.WriteLine(totalSizeInLitres * (1 - spaceTaken));
        }
    }
}
