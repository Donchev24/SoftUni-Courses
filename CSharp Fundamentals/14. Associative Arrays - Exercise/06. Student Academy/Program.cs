namespace _06._Student_Academy
{
    class Student
    {
        public Student(string name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public string Name { get; set; }

        public List<double> Grades { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentName))
                {
                    Student student = new Student(studentName);
                    students.Add(studentName, student);
                }

                students[studentName].Grades.Add(studentGrade);
            }

            foreach (var s in students)
            {
                double averageGrade = s.Value.Grades.Average();
                if (averageGrade >= 4.50)
                {
                    Console.WriteLine($"{s.Key} -> {averageGrade:F2}");
                }
            }
        }
    }
}
