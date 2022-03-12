using System;

namespace Task_2___Average_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            string firstInput = Console.ReadLine();
            Console.WriteLine("Enter second number");
            string secondInput = Console.ReadLine();
            Console.WriteLine("Enter third number");
            string thirdInput = Console.ReadLine();
            Console.WriteLine("Enter fourth number");
            string fourthInput = Console.ReadLine();
            if (!int.TryParse(firstInput, out int firstNum) || 
                !int.TryParse(secondInput, out int secondNum)||
                !int.TryParse(thirdInput, out int thirdNum) || 
                !int.TryParse(fourthInput, out int fourthNum))
            {
                Console.WriteLine("Enter valid number");
                return;
            }
            
            Console.WriteLine("The average is " + ((decimal) firstNum + secondNum + thirdNum +  fourthNum) / 4);
        }
    }
}
