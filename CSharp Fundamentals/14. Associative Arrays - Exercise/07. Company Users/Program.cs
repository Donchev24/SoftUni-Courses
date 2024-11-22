namespace _07._Company_Users
{
    internal class Program
    {
        class Company
        {
            public Company(string companyName)
            {
                Name = companyName;
                EmployeeId = new List<string>();
            }

            public string Name { get; set; }
            public List<string> EmployeeId { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Company> users = new Dictionary<string, Company>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] companyArgs = input.Split(" -> ");
                string companyName = companyArgs[0];
                string employeeId = companyArgs[1];

                if (!users.ContainsKey(companyName))
                {
                    Company company = new Company(companyName);
                    List<string> employee = new List<string>();
                    users.Add(companyName, company);
                }

                users[companyName].EmployeeId.Add(employeeId);
            }

            foreach (var u in users)
            {
                var newList = u.Value.EmployeeId.Distinct().ToList();

                Console.WriteLine($"{u.Key}");
                for (int i = 0; i < newList.Count; i++)
                {
                    Console.WriteLine($"-- {newList[i]}");
                }
            }
        }
    }
}
