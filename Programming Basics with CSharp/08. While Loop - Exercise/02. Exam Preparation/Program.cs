namespace _02._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int unhappyResults = int.Parse(Console.ReadLine());


            int count = 0;
            double totalScore = 0;
            string exercisesName = Console.ReadLine();
            int totalExercise = 0;
            string lastExercise = string.Empty;

            while (exercisesName != "Enough")
            {

                double grade = double.Parse(Console.ReadLine());
                lastExercise = exercisesName;



                if (grade <= 4)
                {
                    count++;
                    if (count == unhappyResults)
                    {
                        Console.WriteLine($"You need a break, {count} poor grades.");
                        break;
                    }
                }


                totalScore += grade;
                totalExercise++;





                exercisesName = Console.ReadLine();
            }


            if (exercisesName == "Enough")
            {
                Console.WriteLine($"Average score: {totalScore / totalExercise:F2}");
                Console.WriteLine($"Number of problems: {totalExercise}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }

        }
    }
}
