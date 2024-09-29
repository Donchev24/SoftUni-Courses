namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            int personsLimit = int.Parse(Console.ReadLine());

            int courses = 0;

            if (persons % personsLimit == 0)
            {
                courses = persons / personsLimit;
            }
            else
            {
                courses = (persons / personsLimit) + 1;
            }

            Console.WriteLine(courses);
        }
    }
}
