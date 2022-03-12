using System;

namespace Task_3___Swap_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            string firstInput = Console.ReadLine();
            Console.WriteLine("Enter second number");
            string secondInput = Console.ReadLine();
  
            if (!int.TryParse(firstInput, out int firstNum) || !int.TryParse(secondInput, out int secondNum))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            Console.WriteLine("First number = "  + firstNum + " Second number = " + secondNum);
            firstNum = firstNum + secondNum;
            secondNum = firstNum - secondNum;
            firstNum = firstNum - secondNum;
            Console.WriteLine("First number = " + firstNum + " Second number = " + secondNum);


        }
    }
}
