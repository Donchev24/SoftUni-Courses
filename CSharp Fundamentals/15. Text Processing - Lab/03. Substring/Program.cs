namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToCut = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(textToCut))
            {
                int start = text.IndexOf(textToCut);
                int end = textToCut.Length;
                text = text.Remove(start, end);
            }

            Console.WriteLine(text);
        }
    }
}
