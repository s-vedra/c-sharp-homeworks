using System.Collections.Generic;

namespace Model
{
    public class Subjects
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Students { get; set; }

        public Subjects(string name)
        {
            Name = name;
            Duration = 40;
            Students = 0;
        }

        public string NumberOfStudents(List<User> students)
        {
            foreach (User student in students)
            {
                if (student.Role == Role.Student)
                {
                    Student studentUser = (Student) student;
                    if (studentUser.CurrentSubject == Name)
                    {
                        Students++;
                    }
                }
               
            }
            return $"There are currently {Students} students listening to {Name}";
        }
    }
}
