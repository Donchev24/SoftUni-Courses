﻿namespace _04._Even_Powers_of_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (double i = 0; i <= n; i += 2)
            {
                Console.WriteLine(Math.Pow(2, i));
            }
        }
    }
}
