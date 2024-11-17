namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> listOfStudents = new List<Student>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] studentDetails = input.Split();

                string firstName = studentDetails[0];
                string lastName = studentDetails[1];
                string age = studentDetails[2];
                string homeTown = studentDetails[3];

                Student student = null;
                foreach (Student s in listOfStudents)
                {
                    if (s.FirstName == firstName && s.LastName == lastName)
                    {
                        student = s;
                    }
                }
                if (student == null)
                {
                    listOfStudents.Add(new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    });
                }
                else
                {
                    student.Age = age;
                    student.HomeTown = homeTown;
                }
            }

            string filterHomeTown = Console.ReadLine();

            List<Student> filteredStudents = listOfStudents.Where(c => c.HomeTown == filterHomeTown).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
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