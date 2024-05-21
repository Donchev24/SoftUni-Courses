namespace _02._AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> gradesOfStudent = new();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentTokens[0];
                decimal grade = decimal.Parse(studentTokens[1]);

                if (!gradesOfStudent.ContainsKey(studentName))
                {
                    gradesOfStudent.Add(studentName, new List<decimal>());
                }

                gradesOfStudent[studentName].Add(grade);
            }
            foreach (KeyValuePair<string, List<decimal>> kvp in gradesOfStudent)
            {

            }

            foreach((string student, List<decimal> grades) in gradesOfStudent)
            {
                string gradeString = string.Join(" ", grades.Select(g => g.ToString("f2")));
                string averageGrade = $"(avg: {grades.Average():f2})";

                Console.WriteLine($"{student} -> {gradeString} {averageGrade}");
            }
        }
    }
}
