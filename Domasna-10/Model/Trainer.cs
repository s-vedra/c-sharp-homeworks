using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Trainer : User
    {
        public Trainer(int index, string firstName, string lastName, Role role, string username, string password) 
            : base(index, firstName, lastName, role, username, password)
        {

        }

        public void ReturnStudents(List<User> students)
        {
            while (true)
            {
                try
                {

                    foreach (User student in students)
                    {
                        if (student.Role.Equals(Role.Student))
                        {
                            Console.WriteLine($"{student.Index} {student.FirstName} {student.LastName}");
                            Console.WriteLine("-------------------------------");
                        }
                    }
                    Console.WriteLine("Type the index of the student you wish to see");
                    string seeStudent = Console.ReadLine();
                    if (!int.TryParse(seeStudent, out int index))
                    {
                        Console.Clear();
                        throw new Exception("Invalid input");
                    }
                    if (index != 0)
                    {
                        Console.Clear();
                        Student student = (Student)students.Single(student => student.Index == index);
                        Console.WriteLine($"{student.FirstName} {student.LastName} {student.CurrentSubject}");
                        Console.WriteLine("Grades:");
                        foreach (int grade in student.Grades)
                        {
                            Console.WriteLine(grade);
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid");
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    continue;
                }
                break;
            }
         

        }
    }
}
