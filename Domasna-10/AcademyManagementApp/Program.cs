using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyManagementApp
{
    internal class Program
    {
        //method to parse the inputs
        public static int Parsing(string userInput)
        {
            try
            {
                if (!int.TryParse(userInput, out int input))
                {
                    throw new Exception("Invalid input, try again");
                }
                return input;
            }
            catch (Exception msg)
            {

                Console.WriteLine(msg.Message);
                return 0;
            }


        }

        //method to login the user
        public static User Login(List<User> users)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your username");
                    string username = Console.ReadLine();
                    foreach (User user in users)
                    {
                        if (user.CheckUsername(username))
                        {
                            Console.WriteLine("Enter your password");
                            string password = Console.ReadLine();
                            if (user.CheckPassword(password))
                            {
                                return user;
                            }
                        }
                    }
                    throw new Exception("Username or password incorrect, try again");
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }

        //method to return the Student
        public static Student ReturnNewStudent(List<User> users)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter index number:");
                    int index = Parsing(Console.ReadLine());
                    if (index == 0)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (User user in users)
                        {
                            //check if the inputed index by the user is already present in the list
                            if (index == user.Index)
                            {
                                throw new Exception("That index number is already taken, please enter another one!");


                            }
                        }
                        Console.WriteLine("Enter First Name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter Last Name");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter username");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        string password = Console.ReadLine();
                        return new Student(index, firstName, lastName, Role.Student, userName, password, "BasicJS", new List<int>() { 0, 0, 0 });
                    }

                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
                return null;
            }

        }

        //method to return the User, if the admin wants to add a new one in the list 
        //hardcoded values for admin and trainer, there is only a method to return a new Student
        public static User AdminAddUser(List<User> users)
        {
            try
            {
                Console.WriteLine("Enter credentials of the user you wish to add");
                Console.WriteLine("Enter role: \n1.Admin \n2.Trainer \n3.Student");
                int roleInput = Parsing(Console.ReadLine());
                Role role = (Role)roleInput;
                if (role == Role.Admin)
                {
                    return new Admin(36, "Bianca", "Renee", Role.Admin, "AdminBianca", "adminBianca12345");
                }
                else if (role == Role.Trainer)
                {
                    return new Trainer(27, "Nevaeh", "Harris", Role.Trainer, "TrainerNeveah", "trainerNeveah12345");
                }
                else if (role == Role.Student)
                {
                    while (true)
                    {
                        Student student = ReturnNewStudent(users);
                        if (student == null)
                        {
                            continue;
                        }
                        return student;
                    }
                }
                else
                {
                    throw new Exception("Please pick 1,2 or 3");
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
                return null;
            }

        }

        //method to register the new user
        public static List<User> Register(List<User> users)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Hello new user! Please enter your role: \n1.Admin \n2.Trainer \n3.Student");
                    int roleInput = Parsing(Console.ReadLine());
                    Role role = (Role)roleInput;
                    if (role == Role.Admin)
                    {
                        Console.Clear();
                        users.Add(new Admin(35, "Alex", "Alexoski", Role.Admin, "AdminAlex", "adminAlex12345"));
                        return users;
                    }
                    else if (role == Role.Student)
                    {
                        Console.WriteLine("Welcome new Student! \nPlease enter your credentials below!");
                        while (true)
                        {
                            Student student = ReturnNewStudent(users);
                            if (student == null)
                            {
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                users.Add(student);
                                break;
                            }
                        }

                    }
                    else if (role == Role.Trainer)
                    {
                        Console.Clear();
                        users.Add(new Trainer(26, "Emily", "Salmon", Role.Trainer, "TrainerEmily", "trainerEmily12345"));
                    }
                    else
                    {
                        throw new Exception("Please pick 1, 2 or 3");
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    continue;
                }

                return users;
            }
            
        }

        //if the user picked to login, procees to this method where he will choose his own actions, if he's an admin, trainer or a student
        public static void ReturningUser(List<User> users, List<Subjects> subjects)
        {
            User user = Login(users);
            Console.Clear();
            while (true)
            {
                try
                {
                  //if the user is a trainer he can see the subjects and students and can only see info about a specific student
                  //he can only see a specific student through his index number
                    Console.WriteLine($"Welcome {user.Role} {user.FirstName}");
                    if (user.Role == Role.Trainer)
                    {
                        Trainer userTrainer = (Trainer)user;
                        Console.WriteLine("1.Subjects \n2.Students \n3.Escape");
                        int answer = Parsing(Console.ReadLine());
                        if (answer.Equals(1))
                        {
                            Console.Clear();
                            subjects.ForEach(subject => Console.WriteLine(subject.NumberOfStudents(users)));
                            break;
                        }
                        else if (answer.Equals(2))
                        {
                            Console.Clear();
                            userTrainer.ReturnStudents(users);
                            break;
                        }
                        else if (answer.Equals(3))
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }
                        else
                        {
                            throw new Exception("Please pick 1,2 or 3");
                        }

                    }
                    //students have the ability to only see their info
                    else if (user.Role == Role.Student)
                    {
                        Student userStudent = (Student)user;
                        Console.WriteLine("Info:");
                        Console.WriteLine($"{userStudent.ReturnInfo()}");
                        Console.WriteLine("Grades:");
                        userStudent.ReturnGrades();
                        break;
                    }
                    //admind can remove/add other users 
                    else if (user.Role == Role.Admin)
                    {
                        while (true)
                        {
                           
                            Admin userAdmin = (Admin)user;
                            Console.WriteLine("1.Add a user \n2.Remove a user \n3.Escape");
                            int answer = Parsing(Console.ReadLine());
                            if (answer.Equals(1))
                            {
                                Console.Clear();
                                User userAdd = AdminAddUser(users);
                                if (userAdd == null)
                                {
                                    continue;
                                }
                                userAdmin.Add(userAdd, users);
                                Console.Clear();
                                users.ForEach(user => Console.WriteLine(user.ReturnInfo()));
                                break;
                            }
                            else if (answer.Equals(2))
                            {
                                Console.Clear();
                                Console.WriteLine("Enter the users index number you wish to remove");
                                int index = Parsing(Console.ReadLine());
                                User userRemove = users.First(user => user.Index.Equals(index));
                                if (userRemove.Index == userAdmin.Index)
                                {
                                    userAdmin.Remove(userRemove, users);
                                    continue;
                                }
                                {
                                    userAdmin.Remove(userRemove, users);
                                    Console.WriteLine($"User {userRemove.ReturnInfo()}removed");
                                    users.ForEach(user => Console.WriteLine(user.ReturnInfo()));
                                    break;
                                }

                            }
                            else if (answer.Equals(3))
                            {
                                Console.WriteLine("Goodbye");
                                break;
                            }
                            else
                            {
                              
                                throw new Exception("Please pick 1, 2 or 3");
                            }
                        }

                    }
                    break;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    continue;
                }

            }
        }

        static void Main(string[] args)
        {

            List<User> users = new List<User>()
            {
                new Trainer(20,"John", "Johnsky", Role.Trainer,"TrainerJohn","trainerJohn12345"),
                new Trainer(21,"Edward", "Edwardsky", Role.Trainer,"TrainerEdward","trainerEdward12345"),
                new Trainer(22,"Maddy", "Myrna", Role.Trainer,"TrainerMaddy","trainerMaddy12345"),
                new Trainer(23,"Carly", "Nevil", Role.Trainer,"TrainerCarly","trainerCarly12345"),
                new Trainer(24,"Brannon", "Cora", Role.Trainer,"TrainerBrannon","aa"),
                new Trainer(25,"Richard", "Ravenna", Role.Trainer,"TrainerRichard","trainerRichard12345"),
                new Admin(30,"Ally", "Hortense", Role.Admin,"AdminAlly","adminAlly12345"),
                new Admin(31,"Bruce", "Britton", Role.Admin, "AdminBruce","adminBruce12345"),
                new Admin(32,"Kira", "Jerold", Role.Admin,"AdminKira","adminKira12345"),
                new Admin(33,"Tory", "Ariel", Role.Admin,"AdminTory","adminTory12345" ),
                new Admin(34,"Tommie", "Robert", Role.Admin,"AdminTommie","adminTommie12345" ),
                new Student(15125,"Bob", "Bobsky", Role.Student,"BobTheStudent","bob123456","BasicC#",new List<int>(){10,10,10}),
                new Student(15126,"Adam", "Adamy", Role.Student,"AdamTheStudent","adam123456","AdvancedJS",new List<int>(){8,9,10}),
                new Student(15127,"Jony", "Bonbony", Role.Student,"JonyTheStudent","jony123456","BasicC#",new List<int>(){6,7,8}),
                new Student(15128,"Stella", "Strella", Role.Student,"StellaTheStudent","stella123456","BasicC#",new List<int>(){10,9,10})

            };
            List<Subjects> subjects = new List<Subjects>()
            {
                new Subjects("BasicC#"),
                new Subjects("AdvancedC#"),
                new Subjects("BasicJS"),
                new Subjects("AdvancedJS")
            };
            Console.WriteLine("Hello user! Choose an option: \n1.Login \n2.Register");
            while (true)
            {
                try
                {
                    int answer = Parsing(Console.ReadLine());
                    if (answer.Equals(1))
                    {
                        ReturningUser(users, subjects);
                    }
                    else if (answer.Equals(2))
                    {
                        Register(users);
                        users.ForEach(user => Console.WriteLine(user.ReturnInfo()));
                    }
                    else
                    {
                        throw new Exception("Please enter 1 or 2");
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
