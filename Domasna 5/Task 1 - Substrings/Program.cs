using System;

namespace Task_1___Substrings
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Substrings();
        }
        public static void Substrings()
        {
            while (true)
            {
                Console.WriteLine("Enter a number");
                string userInput = Console.ReadLine();
                string one = "Hello from SEDC Codeacademy 2022";

                if (!int.TryParse(userInput, out int number) || number > one.Length)
                {
                    Console.WriteLine(one);
                    continue;
                }
               Console.WriteLine($"The first n characters from the string are {one[..number]} and the new length is {number}");
               break;
            }

        }
    }
}

