namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string[] command = Console.ReadLine().ToLower().Split();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        stack.Push(int.Parse(command[1]));
                        stack.Push(int.Parse(command[2]));
                        break;

                    case "remove":
                        int numsToRemove = int.Parse(command[1]);

                        if (numsToRemove <= stack.Count)
                        {
                            for (int i = 0; i < numsToRemove; i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;
                }


                command = Console.ReadLine().ToLower().Split();
            }

            int remainingNums = stack.Count;
            int sum = 0;

            for (int i = 0; i < remainingNums; i++)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
