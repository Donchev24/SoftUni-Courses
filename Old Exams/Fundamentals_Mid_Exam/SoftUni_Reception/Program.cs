namespace SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int customersCapacityPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;

            int hoursNeed = 0;
            int hoursWorkedWithoutBreak = 0;

            if (studentsCount > 0)
            {
                while (studentsCount > 0)
                {
                    if (hoursWorkedWithoutBreak > 0 && hoursWorkedWithoutBreak % 3 == 0)
                    {
                        hoursNeed++;
                        hoursWorkedWithoutBreak = 0;
                    }
                    studentsCount -= customersCapacityPerHour;
                    hoursNeed++;
                    hoursWorkedWithoutBreak++;
                }
            }

            Console.WriteLine($"Time needed: {hoursNeed}h.");
        }
    }
}
