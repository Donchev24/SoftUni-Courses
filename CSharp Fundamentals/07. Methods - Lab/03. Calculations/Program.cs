namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mathAction = Console.ReadLine();
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            ResultOfCalculations(mathAction, firstNumber, secondNumber);
        }

        static void ResultOfCalculations(string action, double firstNumber, double SecondNumber)
        {
            double result = 0;
            if (action == "add")
            {
                result = firstNumber + SecondNumber;
            }
            else if (action == "multiply")
            {
                result = firstNumber * SecondNumber;
            }
            else if (action == "subtract")
            {
                result = firstNumber - SecondNumber;
            }
            else
            {
                result = firstNumber / SecondNumber;
            }
            Console.WriteLine(result);
        }
    }
}