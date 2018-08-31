using System;

namespace ex1
{
    class View
    {
        Controller c = new Controller();
        Secret s = new Secret();
        bool logedIn = false;
        User logedInUser = new User();
        public void menu()
        {
            c.startUp();
            bool go = true;

            while(go)
            {
                if(logedIn)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("1. Change password");
                    Console.WriteLine("2. See all users");
                    Console.WriteLine("3. Personal stuff");
                    Console.WriteLine("4. Logout");
                }
                else
                {
                    Console.WriteLine("1. Register user");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. See all users");
                }
                Console.WriteLine("Q. Exit");
                Console.WriteLine("-----------------------");
                
                string answer = Console.ReadLine().ToUpper();

                if(answer.Equals("Q"))
                {
                    go = false;
                }

                if(logedIn)
                {
                    if(answer.Equals("1"))
                    {
                        changePassword();
                    }
                    else if(answer.Equals("2"))
                    {
                        seeAllUsers();
                    }
                    else if(answer.Equals("3"))
                    {
                        personalMenu(logedInUser);
                    }
                    else if(answer.Equals("4"))
                    {
                        logedInUser = new User();
                        logedIn = false;
                        continue;
                    }
                }
                else
                {
                    if(answer.Equals("1"))
                    {
                        regUser();
                    }
                    else if(answer.Equals("2"))
                    {
                        login();
                    }
                    else if(answer.Equals("3"))
                    {
                        seeAllUsers();
                    }
                }
            }

            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }

        public void personalMenu(User user)
        {
            bool personalGo = true;

            while(personalGo)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Personal Menu");
                Console.WriteLine("1. Personal information");
                Console.WriteLine("2. Notes");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine("-----------------------");
                
                string answer = Console.ReadLine();

                if(answer.Equals("1"))
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Personal Information");
                    Console.WriteLine("Name: " + user.getName());
                    Console.WriteLine("Age: " + user.getAge());
                    Console.WriteLine("Email: " + user.getEmail());
                    Console.WriteLine("Gender: " + user.getGender());
                    Console.WriteLine("Street: " + user.getStreet());
                    Console.Write("Change anything? [Y or N]");
                    answer = Console.ReadLine().ToUpper();

                    if(answer.Equals("Y"))
                    {
                        changePersonalStuff(user);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if(answer.Equals("2"))
                {

                }
                else if(answer.Equals("3"))
                {
                    personalGo = false;
                }
            }

            menu();
        }

        private void changePersonalStuff(User user)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            string age = Console.ReadLine();
            
            Console.Write("Email: ");
            string email = Console.ReadLine();
            
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            
            Console.Write("Street: ");
            string street = Console.ReadLine();

            c.changePersonalStuff(user, name, age, email, gender, street);
        }

        private void changePassword()
        {
            Console.Write("Type name: ");
            string name = Console.ReadLine();

            Console.Write("Old password: ");
            string oldPassword = Console.ReadLine();

            Console.Write("New password: ");
            string newPassword = Console.ReadLine();
            c.changePassword(name, oldPassword, newPassword, logedIn);
        }

        private void seeAllUsers()
        {
            foreach(User u in c.getAllUsers())
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Name  : " + u.getName());
                Console.WriteLine("Email : " + u.getEmail());
                Console.WriteLine("-----------------------");
            }
        }

        public void login()
        {
            Console.Write("Name please: ");
            string name = Console.ReadLine();

            Console.Write("..and password please: ");
            string password = Console.ReadLine();

            if(c.checkUser(name, password))
            {
                Console.WriteLine(s.secretMessage());
                logedIn = true;
                
                foreach(User u in c.getAllUsers())
                {
                    if(u.getName().Equals(name))
                    {
                        logedInUser = u;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
            }
        }

        public void regUser()
        {
            Console.Write("Name please: ");
            string userName = Console.ReadLine();

            Console.Write("..and password please: ");
            string userPassword = Console.ReadLine();

            Console.WriteLine(c.addUser(userName, userPassword));
        }
    }
}