namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int brokenHeadset = 0;
            int brokenMouse = 0;
            int brokenKeyboard = 0;
            int brokenDisplay = 0;

            if (lostGames >= 2)
            {
                brokenHeadset = lostGames / 2;
            }

            if (lostGames >= 3)
            {
                brokenMouse = lostGames / 3;
            }
            if (lostGames >= 6)
            {
                brokenKeyboard = lostGames / 6;
            }
            if (lostGames >= 12)
            {
                brokenDisplay = lostGames / 12;
            }

            double totalCost = (brokenHeadset * headsetPrice) + (brokenMouse * mousePrice) + (brokenKeyboard * keyboardPrice) + (brokenDisplay * displayPrice);

            Console.WriteLine($"Rage expenses: {totalCost:F2} lv.");
        }
    }
}
