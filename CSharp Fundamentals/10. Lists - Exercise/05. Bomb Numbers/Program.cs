namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> detonator = Console.ReadLine().Split().Select(int.Parse).ToList();

            int number = detonator[0];
            int power = detonator[1];

            while (list.Contains(number))
            {
                int index = list.IndexOf(number);

                int leftIndex = Math.Max(0, index - power);
                int rightIndex = Math.Min(list.Count - 1, index + power);

                int range = rightIndex - leftIndex + 1;
                list.RemoveRange(leftIndex, range);
            }

            Console.WriteLine(list.Sum());
        }
    }
}
