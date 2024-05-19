namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> childrenNames = new (
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));    //Alva James William   2


            int hotPotato = int.Parse(Console.ReadLine());
            int count = 0;

            while (childrenNames.Count > 1)
            {
                count++;

                if (hotPotato == count)
                {
                    Console.WriteLine($"Removed {childrenNames.Dequeue()}");
                    count = 0;
                }
                else
                {
                    childrenNames.Enqueue(childrenNames.Dequeue());
                }

                
            }

            Console.WriteLine($"Last is {childrenNames.Dequeue()}");
        }
    }
}
