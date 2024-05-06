namespace _05._Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            string website;

            for (int i = 1; i <= tabs; i++)
            {
                website = Console.ReadLine();

                if (website == "Facebook")
                    salary -= 150;
                else if (website == "Instagram")
                    salary -= 100;
                else if (website == "Reddit")
                    salary -= 50;


                if (salary <= 0)
                {
                    Console.WriteLine($"You have lost your salary.");
                    break;
                }

            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
