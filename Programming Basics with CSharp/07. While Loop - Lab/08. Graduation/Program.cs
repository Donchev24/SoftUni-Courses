namespace _08._Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int grade = 1;
            double annualGrade = 0;
            int fails = 0;
            double totalScore = 0;

            while (grade <= 12)
            {
                annualGrade = double.Parse(Console.ReadLine());

                if (annualGrade < 4)
                {
                    fails++;
                    if (fails < 2)
                    {

                        continue;
                    }

                    else
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                }

                grade++;
                totalScore += annualGrade;
            }

            double avarageGrade = totalScore / 12;

            if (grade >= 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {avarageGrade:F2}");
            }
        }
    }
}
