namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstText = Console.ReadLine().Split();
            string[] secondText = Console.ReadLine().Split();

            for (int i = 0; i < secondText.Length; i++)
            {
                for (int y = 0; y < firstText.Length; y++)
                {
                    if (secondText[i] == firstText[y])
                    {
                        Console.Write($"{secondText[i]} ");
                    }
                }
            }
        }
    }
}
