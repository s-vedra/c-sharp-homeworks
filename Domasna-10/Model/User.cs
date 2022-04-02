using System;

namespace Model
{
    public class User
    {
        public int Index { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }


        public User(int index,string firstName, string lastName, Role role, string username, string password)
        {
            Index = index;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Username = username;
            Password = password;
        }

        public bool CheckUsername(string username)
        {
            if (Username == username)
            {
                return true;
            }
            return false;
        }
        public bool CheckPassword(string password)
        {
            if (Password == password)
            {
                return true;
            }
         return false;
        }
        public virtual string ReturnInfo()
        {
            return $"Full Name: {FirstName} {LastName} {Role} ";
        }
    }
}
