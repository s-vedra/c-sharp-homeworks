using System;
using System.Collections.Generic;

namespace Model
{
    public class Admin : User
    {

        public Admin(int index, string firstName, string lastName, Role role, string username, string password)
            : base(index, firstName, lastName, role, username, password)
        {

        }

        public List<User> Remove(User user, List<User> users)
        {
            try
            {

                if (user.Index == Index)
                {
                    throw new Exception("You can't do that");
                }
               
                else
                {
                    users.Remove(user);
                    return users;
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);


            }
            return users;

        }

        public List<User> Add(User user, List<User> users)
        {
            users.Add(user);
            return users;
        }

        public override string ReturnInfo()
        {
            return base.ReturnInfo();
        }
    }
}
