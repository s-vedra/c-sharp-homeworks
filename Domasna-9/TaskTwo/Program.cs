using System;
using System.Collections.Generic;

namespace TaskTwo
{
    internal class Program
    {
        public static int InputNumber()
        {
            while (true)
            {
                Console.WriteLine("Input a number");
                string inputNum = Console.ReadLine();
                if (!int.TryParse(inputNum, out int num))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                return num;
            }
            
        }
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
            
            while (true)
            {
                numbers.Enqueue(InputNumber());
                Console.WriteLine("Do you want to enter another number?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    continue;
                }
                else if (answer == "no")
                {
                    break;
                }
                break;
            }

            foreach (int num in numbers)
            {
                Console.WriteLine("Numbers:");
                Console.WriteLine(num);
            }
            
        }
    }
}
