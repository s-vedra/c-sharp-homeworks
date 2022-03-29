namespace Model
{
    public class SalesPerson : Employee
    {
        private double SuccessSaleRevenue { get; set; }

        public SalesPerson(string firstName, string lastName, double successSaleRev) : base(firstName, lastName, Roles.Sales, 500)
        {
            SuccessSaleRevenue = successSaleRev;
        }

        public double AddSuccessRevenue(double amount)
        {
            return SuccessSaleRevenue += amount;
        }

        public override double ReturnSalary()
        {
            double bonus = 0;
            if (SuccessSaleRevenue <= 2000)
            {
                return bonus = 500 + Salary;
            }
            else if (SuccessSaleRevenue > 2000 && SuccessSaleRevenue <= 5000)
            {
                return bonus = 1000 + Salary;
            }
            else if (SuccessSaleRevenue > 5000)
            {
                return 1500 + Salary;
            }
            else
            {
                return 0 + Salary;
            }

        }
    }
}
