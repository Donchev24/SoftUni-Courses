namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string student = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!studentGrades.ContainsKey(student))
                {
                    studentGrades.Add(student, new List<decimal>());
                }

                studentGrades[student].Add(grade);
            }

            foreach (var (student, grade) in studentGrades)
            {
                string gradeString = string.Join(" ", grade.Select(g => g.ToString("F2")));

                Console.WriteLine($"{student} -> {gradeString} (avg: {grade.Average():F2})");
            }
        }
    }
}
