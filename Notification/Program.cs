using Post;
using User;
using Admin;
using Notification;
using Base;
using System;
using System.Threading;

Postc post1 = new("Hakuna", DateTime.Now);
Postc post2 = new("Matata", new DateTime(2023, 1, 14, 2, 59, 45));
Userc niqa = new("Nigar", "Mustafazada", 19, "nigarrmustafazada@gmail.com", "N1g3A5r");
Adminc nigars = new("m.nigar", "nigarrmustafazadeh@gmail.com", "fly2");
Basecs data = new();

nigars.posts.Add(post1);
nigars.posts.Add(post2);

data.users.Add(niqa);
data.admins.Add(nigars);

bool AdminCheck(string admin, string password, List<Adminc> list)
{
    if (admin.Contains("@"))
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (admin == list[i].email)
            {
                if (password == list[i].password)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
    else
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (admin == list[i].username)
            {
                if (password == list[i].password)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
}
bool UserCheck(string user, string password, List<Userc> list)
{
    if (user.Contains("@"))
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (user == list[i].email)
            {
                if (password == list[i].password)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
    else
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (user == list[i].name)
            {
                if (password == list[i].password)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
}

bool PostCheck(int index, List<Postc> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        if (index == list[i].id)
        {
            return true;
        }
    }
    return false;
}

Userc? User(string usersname, List<Userc> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        if (usersname == list[i].name)
        {
            return list[i];
        }
    }
    return null;
}

void AdminMenu()
{
labellogin:
    Console.Clear();
    Console.WriteLine("Enter username/email: ");
    string input = Console.ReadLine();
    Console.WriteLine("Enter password: ");
    string passchck = Console.ReadLine();
    if (AdminCheck(input, passchck, data.admins))
    {
    labelmenu:
        Console.Clear();
        Console.WriteLine("1.Posts");
        Console.WriteLine("2.Notifications");
        Console.WriteLine("0.Back");
        input = Console.ReadLine();
        if (input == "1")
        {
        labelposts:
            Console.Clear();
            for (int i = 0; i < data.admins[0].posts.Count; i++)
            {
                data.admins[0].posts[i].ShowPosts();
            }
            Console.WriteLine("Enter post id:");
            Console.WriteLine("0.Back");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id == 0)
            {
                goto labelmenu;
            }
            else if (PostCheck(id, data.admins[0].posts))
            {
                Console.Clear();
                data.admins[0].posts[id - 1].viewCount++;
                data.admins[0].posts[id - 1].ShowPosts();
                Console.WriteLine("1.Remove post");
                Console.WriteLine("0.Back");
                input = Console.ReadLine();
                if (input == "1")
                {
                    data.admins[0].posts.Remove(data.admins[0].posts[id - 1]);
                    Console.Clear();
                    Console.WriteLine("Post removed");
                    Thread.Sleep(1000);
                    goto labelposts;
                }
                else if (input == "0")
                    goto labelmenu;
                else
                {
                    Console.WriteLine("Your choice is wrong");
                    goto labelposts;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your choice is wrong");
                Thread.Sleep(1000);
                goto labelposts;
            }
        }
        else if (input == "2")
        {
        labelnotifications:
            Console.Clear();
            for (int i = 0; i < data.admins[0].notifications.Count; i++)
            {
                data.admins[0].notifications[i].ShowNotification();
            }
            Console.WriteLine("1.Clear notification");
            Console.WriteLine("0.Back");
            input = Console.ReadLine();
            if (input == "1")
            {
                data.admins[0].notifications.Clear();
                Console.Clear();
                Console.WriteLine("Notification removed");
                Thread.Sleep(1000);
                goto labelnotifications;
            }
            else if (input == "0")
            {
                goto labelmenu;
            }
            else
            {
                Console.WriteLine("Your choice is wrong");
                goto labelnotifications;
            }
        }
        else if (input == "0")
        {
            Main();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Your choice is wrong");
            Thread.Sleep(3000);
            goto labellogin;
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("You entered wrong username/email or password");
        Thread.Sleep(3000);
        goto labellogin;
    }
}

void UserMenu()
{
labellogin:
    Console.Clear();
    Console.WriteLine("Enter username/email: ");
    string usersname = Console.ReadLine();
    Console.WriteLine("Enter password: ");
    string passwordcheck = Console.ReadLine();
    if (UserCheck(usersname, passwordcheck, data.users))
    {
    labelposts:
        Console.Clear();
        for (int i = 0; i < data.admins.Count; i++)
        {
            for (int j = 0; j < data.admins[i].posts.Count; j++)
            {
                data.admins[i].posts[j].ShowPosts();
            }
        }
        Console.WriteLine("Enter post id for view");
        Console.WriteLine("0.Back");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id == 0)
        {
            Main();
        }
        else if (PostCheck(id, data.admins[0].posts))
        {
            Console.Clear();
            data.admins[0].posts[id - 1].viewCount++;
            data.admins[0].posts[id - 1].ShowPosts();
            Console.WriteLine("1.Like");
            Console.WriteLine("0.Back");
            string userinput = Console.ReadLine();
            if (userinput == "1")
            {
                data.admins[0].posts[id - 1].likeCount += 1;
                Console.Clear();
                Console.WriteLine("You liked this post:)");
                Thread.Sleep(3000);
                data.admins[0].notifications.Add(new Notificationc($"{usersname} liked {id} post", DateTime.Now, User(usersname, data.users)));
                goto labelposts;
            }
            else
                goto labelposts;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Wrong choice,try again");
            Thread.Sleep(3000);
            goto labelposts;
        }

    }
    else
    {
        Console.Clear();
        Console.WriteLine("Wrong username(email) or password");
        Thread.Sleep(3000);
        goto labellogin;
    }
}

void Main()
{
    Console.Clear();
    Console.WriteLine("1.Admin");
    Console.WriteLine("2.User");
    string? userinput = Console.ReadLine();
    if (userinput == "1")
    {
        AdminMenu();
    }
    else if (userinput == "2")
    {
        UserMenu();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Wrong choice,try again");
        Thread.Sleep(1000);
        Main();
    }
}

Main();