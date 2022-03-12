using System;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number");
            string firstInput = Console.ReadLine();
            Console.WriteLine("Enter second number");
            string secondInput = Console.ReadLine();
            Console.WriteLine("Enter operation");
            string operation = Console.ReadLine();
            if (!decimal.TryParse(firstInput, out decimal firstNum) || !decimal.TryParse(secondInput,out decimal secondNum))
            {
                Console.WriteLine("Enter a valid number");
                return;
            }
            switch (operation)
            {
                case "+":
                    Console.WriteLine(firstNum + secondNum);
                    break;
                case "-":
                    Console.WriteLine(firstNum - secondNum);
                    break;
                case "*":
                    Console.WriteLine(firstNum * secondNum);
                    break;
                case "/":
                    Console.WriteLine(firstNum / secondNum);
                    break;
                default:
                    Console.WriteLine("Enter a valid operator");
                    break;
            }

        }
    }
}
