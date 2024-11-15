namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();

            List<string> input = Console.ReadLine().Split().ToList();

            while (input[0] != "end")
            {
                if (input[0] == "Delete")
                {
                    numbers.RemoveAll(item => item == input[1]);
                }
                else
                {
                    numbers.Insert(int.Parse(input[2]), input[1]);
                }

                input = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
