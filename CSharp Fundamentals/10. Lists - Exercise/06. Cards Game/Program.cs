namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayer = Console.ReadLine().Split().Select(int.Parse).ToList();

            int biggerDeckOfCards = Math.Min(firstPlayer.Count, secondPlayer.Count);
            for (int i = 0; i < biggerDeckOfCards; i++)
            {
                if (firstPlayer.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
                    break;
                }
                if (secondPlayer.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
                    break;
                }

                int firstPlayerCard = firstPlayer[i];
                int secondPlayerCard = secondPlayer[i];

                if (firstPlayerCard > secondPlayerCard)
                {
                    firstPlayer.Add(firstPlayerCard);
                    firstPlayer.Add(secondPlayerCard);
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                    i--;
                }
                else if (secondPlayerCard > firstPlayerCard)
                {
                    secondPlayer.Add(secondPlayerCard);
                    secondPlayer.Add(firstPlayerCard);
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                    i--;
                }

                else
                {
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
