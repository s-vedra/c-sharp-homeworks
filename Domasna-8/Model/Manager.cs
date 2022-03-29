namespace Model
{
    public class Manager : Employee
    {
        private double Bonus { get; set; }
        public string Departmet { get; set; }

        public Manager(string firstName, string lastName, double salary, string department) : base(firstName, lastName, Roles.Manager, salary)
        {
            Departmet = department;
        }

        public double AddBonus(int bonus)
        {
            return Bonus += bonus;
        }

        public override double ReturnSalary()
        {
            return Bonus + Salary;
        }

    }
}
