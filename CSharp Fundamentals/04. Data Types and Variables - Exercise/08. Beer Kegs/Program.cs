namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string biggestModel = "";
            double biggestVolume = double.MinValue;
            for (int i = 0; i < num; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int hight = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * hight;

                if (volume >= biggestVolume)
                {
                    biggestVolume = volume;
                    biggestModel = model;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
