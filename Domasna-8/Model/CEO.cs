using System;

namespace Model
{
    public class CEO : Employee
    {
        public Employee[] Employess { get; set; }
        public int Shares { get; set; }
        private double SharesPrice { get; set; }

        public CEO(string firstName, string lastName, int shares) : base(firstName, lastName, Roles.CEO, 100000)
        {
            Shares = shares;
        }
        public double AddSharesPrice(double num)
        {
            return SharesPrice = num;
        }
        public void PrintEmployees(Employee[] employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.PrintInfo());
            }
        }
        public override double ReturnSalary()
        {
            return Salary + Shares * SharesPrice;
        }
    }
}
