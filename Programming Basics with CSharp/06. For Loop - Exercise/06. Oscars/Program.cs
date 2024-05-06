namespace _06._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int assessors = int.Parse(Console.ReadLine());

            string assessorName;
            double assessorScore = 0;


            for (int i = 1; i <= assessors; i++)
            {
                assessorName = Console.ReadLine();
                assessorScore = double.Parse(Console.ReadLine());

                points += (assessorName.Length * assessorScore / 2);

                if (points >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {points:F1}!");
                    break;
                }
            }

            if (points < 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - points:F1} more!");
            }
        }
    }
}
