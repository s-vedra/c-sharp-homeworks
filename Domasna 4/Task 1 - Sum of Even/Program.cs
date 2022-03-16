using System;

namespace Task_1___Sum_of_Even
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = new int[6];
            int sum = 0;
            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    Console.WriteLine("Enter the number for position " + (i+1));
                    string inputNumber = Console.ReadLine();
                    if (int.TryParse(inputNumber, out int number))
                    {
                        numArr[i] += number;
                        break;
                        
                    }
                    Console.WriteLine("Invalid number");
                    continue;
                }
            }
            foreach(int num in numArr)
            {
                if (num % 2 == 0)
                {
                    sum += num;
                }
                
            }
            Console.WriteLine("The sum of even numbers is " + sum);
        }
    }
}
