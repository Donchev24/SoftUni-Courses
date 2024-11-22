namespace _05._Courses
{
    class Course
    {
        public Course(string courseName)
        {
            Name = courseName;
            StudentNames = new List<string>();
        }

        public string Name { get; set; }
        public List<string> StudentNames { get; set; }

        public override string ToString()
        {
            string result = $"{Name}: {StudentNames.Count}\n";
            for (int i = 0; i < StudentNames.Count; i++)
            {
                result += $"-- {StudentNames[i]}\n";
            }

            return result.Trim();
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, Course> courses = new Dictionary<string, Course>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] courseArgs = input.Split(" : ");
                string courseName = courseArgs[0];
                string studentName = courseArgs[1];

                if (!courses.ContainsKey(courseName))
                {
                    Course course = new Course(courseName);
                    courses.Add(courseName, course);
                }

                courses[courseName].StudentNames.Add(studentName);
            }

            foreach (Course c in courses.Values)
            {
                Console.WriteLine(c);
            }
        }
    }
}
