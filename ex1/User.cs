using System;

namespace ex1
{
    class User
    {
        private string name;
        private string password;
        private string email;
        private string gender;
        private string age;
        private string street;

        public User(string name, string password) 
        {
            this.name = name;
            this.password = password;
        }

        public User()
        {

        }

        public void setName(string name) => this.name = name;

        public string getName() => this.name;

        public void setPassword(string password) => this.password = password;

        public string getPassword() => this.password;

        public void setEmail(string email) => this.email = email;

        public string getEmail() => this.email;

        public void setGender(string gender) => this.gender = gender;

        public string getGender() => this.gender;

        public void setAge(string age) => this.age = age;

        public string getAge() => this.age;

        public void setStreet(string street) => this.street = street;

        public string getStreet() => this.street;

        public string userAddedToString() => this.name + " has been added to the system";
    }
}