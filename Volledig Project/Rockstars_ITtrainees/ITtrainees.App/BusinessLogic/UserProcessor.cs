using System;
using System.Collections.Generic;
using System.Text;
using ITtrainees.App.Models;

namespace ITtrainees.App.BusinessLogic
{
    public static class UserProcessor
    {
        //ik heb de users list gebruikt als tijdelijke data storage om mee te testen
        static List<User> users = new List<User>();

        public static void CreateUser(string firstName, string lastName)
        {
            User user = new User
            {
                FirstName = firstName,
                LastName = lastName
            };

            //user moet geschreven worden naar database ipv users list
            users.Add(user);
        }

        //LoadUsers() moet data ophalen uit database ipv de static users list
        public static List<User> LoadUsers()
        {
            return users;
        }
    }
}
