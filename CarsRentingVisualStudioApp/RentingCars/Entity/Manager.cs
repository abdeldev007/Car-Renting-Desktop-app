using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Entity
{
    class Manager
    {
         

        private string phone_number;

        public string Phone_Number
        {
            get { return phone_number; }
            set { phone_number = value; }
        }

        private string first_name;

        public string First_Name
        {
            get { return first_name; }
            set { first_name = value; }
        }

        private string last_name;

        public string Last_Name
        {
            get { return last_name; }
            set { last_name = value; }
        }

         

        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }



        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


    }
}
