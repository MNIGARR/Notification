using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//User => id,name,surname,age,email,password

namespace User
{
    internal class Userc
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public static int Id;


        public Userc(string Name, string Surname, int Age, string Email, string Password)
        {
            id = ++Id;
            name = Name;
            surname = Surname;
            age = Age;
            email = Email;
            password = Password;
        }


    }
}
