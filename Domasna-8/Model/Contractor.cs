namespace Model
{
    public class Contractor : Employee
    {
        public double WorkHours { get; set; }
        public int PayPerHour { get; set; }

        public Manager Responsible { get; set; }

        public Contractor(string firstName, string lastName, double workHours, int payPerHour, Manager manager) : base(firstName, lastName, Roles.Contractor, 0)
        {
            WorkHours = workHours;
            PayPerHour = payPerHour;
            Responsible = manager;
        }

        public override double ReturnSalary()
        {
            return Salary = WorkHours * PayPerHour;
        }

        public string CurrentPosition()
        {
            return $"The current department of the Manager that is responsible for {FirstName} {LastName} is {Responsible.Departmet}";
        }
    }
}
