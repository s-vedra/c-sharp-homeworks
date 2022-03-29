using Model;
using System;

namespace TaskOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manOne = new Manager("Gwen", "Ten", 2500, "Marketing");
            Manager manTwo = new Manager("Harry", "Potter", 2500, "IT");
            Manager manThree = new Manager("Gumball", "Watterson", 2500, "Sales");
            Contractor concOne = new Contractor("Bob", "Bobsky", 40, 35, manOne);
            Contractor concTwo = new Contractor("Ronald", "McDonald", 40, 45, manTwo);
            Contractor concThree = new Contractor("Johnny", "Test", 40, 25, manThree);
            SalesPerson salesOne = new SalesPerson("Rick", "Sanchez", 0);

            Employee[] company = { manOne, manTwo, manThree, concOne, concTwo, concThree, salesOne };

            manOne.AddBonus(1500);
            manTwo.AddBonus(1000);
            manThree.AddBonus(1500);
            Console.WriteLine($"{concOne.PrintInfo()} \n{concTwo.PrintInfo()} \n{concThree.PrintInfo()}");
            salesOne.AddSuccessRevenue(1000);

            CEO ceo = new CEO("Ben", "Ten", 7);

            Console.WriteLine($"Info of CEO \n{ceo.PrintInfo()}");
            ceo.AddSharesPrice(17.5);
            Console.WriteLine($"Salary:{ceo.ReturnSalary():C}");
            Console.WriteLine("Employees:");
            ceo.PrintEmployees(company);

        }
    }
}
