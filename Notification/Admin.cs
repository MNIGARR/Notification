using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Post;
using Notification;

//Admin => id,username,email,password,Posts,Notifications

namespace Admin
{
    internal class Adminc
    {

        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public List<Postc> posts = new();
        public List<Notificationc> notifications = new();

        public Adminc(string usernm, string mail, string pswrd)
        {
            username = usernm;
            email = mail;
            password = pswrd;
        }
    }
}
