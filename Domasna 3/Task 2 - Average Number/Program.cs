using System;

namespace Task_2___Average_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter four numbers");

            if (!decimal.TryParse(Console.ReadLine(), out decimal firstNum) || 
                !decimal.TryParse(Console.ReadLine(), out decimal secondNum)||
                !decimal.TryParse(Console.ReadLine(), out decimal thirdNum) || 
                !decimal.TryParse(Console.ReadLine(), out decimal fourthNum))
            {
                Console.WriteLine("Enter valid number");
                return;
            }
            
            Console.WriteLine("The average is " + (firstNum + secondNum + thirdNum +  fourthNum) / 4);
        }
    }
}
