namespace _04._Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double allPresentationsScore = 0;

            int count = 0;
            int allScores = 0;

            while (presentationName != "Finish")
            {
                double totalScore = 0;
                count++;

                for (int i = 1; i <= judges; i++)
                {
                    double score = double.Parse(Console.ReadLine());
                    allScores++;
                    totalScore += score;
                    allPresentationsScore += score;
                }

                double averageScore = totalScore / judges;


                Console.WriteLine($"{presentationName} - {averageScore:f2}.");


                presentationName = Console.ReadLine();
            }

            double allPresentationAverageScore = allPresentationsScore / allScores;

            if (count > 0)
            {
                Console.WriteLine($"Student's final assessment is {allPresentationAverageScore:f2}.");
            }
        }
    }
}
