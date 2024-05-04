namespace _06._Vowels_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if ((char)text[i] == 'a')
                    sum += 1;

                else if ((char)text[i] == 'e')
                    sum += 2;

                else if ((char)text[i] == 'i')
                    sum += 3;
                else if ((char)text[i] == 'o')
                    sum += 4;
                else if ((char)text[i] == 'u')
                    sum += 5;
            }

            Console.WriteLine(sum);
        }
    }
}
