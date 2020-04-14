using AIWM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AIWM.Database
{
    public class UserDao
    {
        readonly DatabaseContext dbc = new DatabaseContext();
        public User FindUserByName(String login)
        {
            var foundUser = dbc.Users.Where(user => user.Login == login);
            if (foundUser.Any())
                {
                    return foundUser.First();
                }

            return null;
        }

        public void AddUser(User user)
        {
            dbc.Users.Add(user);
            dbc.SaveChanges();
        }

    }
}
