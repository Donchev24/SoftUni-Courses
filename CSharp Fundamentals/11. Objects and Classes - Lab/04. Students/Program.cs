namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] studentDetails = input.Split();
                Student student = new Student()
                {
                    FirstName = studentDetails[0],
                    LastName = studentDetails[1],
                    Age = studentDetails[2],
                    HomeTown = studentDetails[3]
                };

                students.Add(student);
            }

            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}
