using System;

namespace Task_2___Age_Calculator
{
    internal class Program
    {
        public static void BirthDate()
        {
            while (true)
            {
                Console.WriteLine("Enter birth year, birth month and birth day in the respective order");
                if (!int.TryParse(Console.ReadLine(), out int year) ||
                !int.TryParse(Console.ReadLine(), out int month) ||
                !int.TryParse(Console.ReadLine(), out int day))
                {
                    Console.WriteLine("Invalid number");
                    continue;
                } 
                    Console.WriteLine($"Your age is {AgeCalculator(year, month, day)}");
                    break;
            }
        }
        public static int AgeCalculator(int year, int month, int day)
        {
            DateTime currentDate = DateTime.UtcNow;
            DateTime date = new DateTime(year, month, day);
            int age = currentDate.Year - date.Year;
            if (currentDate.Month < date.Month || (currentDate.Month == date.Month && currentDate.Day < date.Day))
            {
                age--;
            }
            return age;
        }
        static void Main(string[] args)
        {
            BirthDate();
            
        }
    }
}
