namespace Model
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        protected double Salary { get; set; }

        public Employee(string firstName, string lastName, Roles role, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Salary = salary;
        }

        public string PrintInfo()
        {
            return $"First name: {FirstName} Last name: {LastName} Salary: {ReturnSalary():C}";
        }

        public virtual double ReturnSalary()
        {
            return Salary;
        }
    }
}
