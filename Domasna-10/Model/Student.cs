using System;
using System.Collections.Generic;

namespace Model
{
    public class Student : User
    {
        public string CurrentSubject { get; set; }
        public List<int> Grades = new List<int>();
        public Student(int index, string firstName, string lastName, Role role, string username, string password, string currentSub, List<int> grades)
            : base(index, firstName, lastName, role, username, password)
        {
            CurrentSubject = currentSub;
            Grades = grades;
        }

        public void ReturnGrades()
        {
          Grades.ForEach(grade => Console.WriteLine(grade));
        }
        public override string ReturnInfo()
        {
            return $"{base.ReturnInfo()} Current Subject: {CurrentSubject}";
        }
    }
}
