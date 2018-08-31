using System;
using System.Collections.Generic;

namespace ex1
{
    class Controller
    {
        private const string filePath = "C:\\Users\\wagnbmic\\Code\\C#\\CsharpStuff\\ex1\\users.txt";
        List<User> listOfUsers = new List<User>();
        string[] onFileArr = System.IO.File.ReadAllLines(filePath);

        public void startUp()
        {
            foreach(string line in onFileArr)
            {
                User newUser = new User();
                string[] aUser = line.Split(";");
                newUser.setName(aUser[0]);
                newUser.setPassword(aUser[1]);
                listOfUsers.Add(newUser);
            }
        }
        public string addUser(string userName, string userPassword)
        {
            foreach(User n in listOfUsers)
            {
                if(n.getName().ToLower().Equals(userName.ToLower()))
                {
                    return "User allready exicts";
                }
            }
            string[] userArr = {userName + ";" + userPassword};
            foreach(string line in onFileArr)
            {
                userArr[userArr.Length - 1] += Environment.NewLine + line;
            }
            
            System.IO.File.WriteAllLines(filePath, userArr);
            User newUser = new User(userName, userPassword);
            listOfUsers.Add(newUser);
            
            return newUser.userAddedToString();
        }

        public List<User> getAllUsers()
        {            
            return this.listOfUsers;
        }

        public bool checkUser(string userName, string userPassword)
        {
            foreach(User u in listOfUsers)
            {
                if(u.getName().Equals(userName))
                {
                    if(u.getPassword().Equals(userPassword))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public void changePassword(string userName, string oldPassword, string newPassword, bool logedIn)
        {
            if(checkUser(userName, oldPassword) && logedIn)
            {
                foreach(User u in listOfUsers)
                {
                    if(u.getName().Equals(userName))
                    {
                        u.setPassword(newPassword);
                        Console.WriteLine("New password set!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        public void changePersonalStuff(User user, string name, string age, string email, string gender, string street)
        {
            user.setName(name);
            user.setAge(age);
            user.setEmail(email);
            user.setGender(gender);
            user.setStreet(street);
        }
    }
}