using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User;

namespace Notification
{
    internal class Notificationc
    {
        public int Id { get; }

        public string Text { get; set; }

        public DateTime dateTime { get; set; }

        public Userc FromUser { get; set; }

        public Notificationc(string text, DateTime dateTime, Userc fromUser)
        {
            Text = text;
            this.dateTime = dateTime;
            this.FromUser = fromUser;
        }

        public void ShowNotification()
        {
            Console.WriteLine($"{Id} Notification");
            Console.WriteLine(Text);
            Console.WriteLine($"Date : {dateTime}");
        }
    }
}
