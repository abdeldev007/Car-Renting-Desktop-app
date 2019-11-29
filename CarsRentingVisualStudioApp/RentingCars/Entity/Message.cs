using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Entity
{
    class Message
    {
        private string message;

        public string Message_to_Clients
        {
            get { return message; }
            set { message = value; }
        }

        private string username;

        public string Username_Message
        {
            get { return username; }
            set { username = value; }
        }
        private DateTime date_message;

        public DateTime Date_Message
        {
            get { return date_message; }
            set { date_message = value; }
        }
    }
}
