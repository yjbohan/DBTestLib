using System;
using System.Collections.Generic;
using System.Text;

namespace DBTestLib
{
    class UsersController
    {
        private readonly PRSContext _context;
        public UsersController(PRSContex contex)
        {
            _context = context;
        }
        /// <summary>
        /// Returns a user if the username and password are found
        /// in the users table of the database
        /// </summary>
        /// <param name="username">The username as a string</param>
        /// <param name="password">The password as a string</param>
        /// <returns></returns>
        /// A user instance if the username and password combination 
        /// is found.  Else returns null.
        /// </returns>
        public Users Login(string username, string password)
        {
            //why does this work??  FIND, you Users only with PK, you can't use find.  But in this case, we want one user instance, and and SingleoRDefault (True or Null)
            _context.Users.SingleORDefault(u => u.UserName == username && u.Password == password);
            return user;
            //Users is only one instance of a User.  We want only one User returned.
        }
    }
}
