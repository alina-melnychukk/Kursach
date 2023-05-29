using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Users
    {
        public List<User> UserList { get; set; } = new List<User>();    
    }

    [Serializable]
    public class User
    {
        public string Name { get; set; } 
        public string Password { get; set; }
        public double Calories { get; set; }

        public User() { }

        public User(string name, string password, long calories)
        {
            Name = name;
            Password = password;
            Calories = calories;
        }
    }
}
