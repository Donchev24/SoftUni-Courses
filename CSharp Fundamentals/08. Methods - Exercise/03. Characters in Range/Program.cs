﻿namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            if (first > second)
            {
                char swapTemp = first;
                first = second;
                second = swapTemp;
            }

            PrintBetween(first, second);

        }

        private static void PrintBetween(char first, char second)
        {
            for (int i = first + 1; i < second; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
