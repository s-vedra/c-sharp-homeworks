using System;

namespace Student_Group
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] G1 = new string[0];
            string[] G2 = new string[0];
            while (true)
            {
                Console.WriteLine("Type the group where you want to add your students");
                string answer = Console.ReadLine();
                if (answer != "G1" && answer != "g1" && answer != "G2" && answer != "g2")
                {
                    Console.WriteLine("The group can't be found");
                    continue;
                }
                for (int i = 0; i < 5; i++)
                {

                    string inputStudent = Console.ReadLine();
                    if (answer == "G1" || answer == "g1")
                    {

                        Array.Resize(ref G1, G1.Length + 1);
                        G1[^1] = inputStudent;

                    }
                    else if (answer == "G2" || answer == "g2")
                    {
                        Array.Resize(ref G2, G2.Length + 1);
                        G2[^1] = inputStudent;

                    }
                }
                while (true)
                {
                    Console.WriteLine("Enter student group:");
                    string grupa = Console.ReadLine();
                    if (!int.TryParse(grupa, out int numberGroup))
                    {
                        Console.WriteLine("Invalid number");
                        continue;
                    }
                    if (numberGroup == 1)
                    {
                        if (G1.Length != 0 && G1 != null)
                        {
                            Console.WriteLine("Students in G1");
                            foreach (string students in G1)
                            {
                                Console.WriteLine(students);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There are no students in this group");
                            continue;
                        }
                    }
                    else if (numberGroup == 2)
                    {
                        if (G2.Length != 0 && G2 != null)
                        {
                            Console.WriteLine("Students in G2");
                            foreach (string students in G2)
                            {
                                Console.WriteLine(students);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There are no students in this group");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The group doesn't exist");
                        continue;
                    }
                }
                break;

            }

        }
    }
}
