using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.DAO
{
    class Orders
    {
        private int id_car;

        public int ID_Car
        {
            get { return id_car; }
            set { id_car = value; }
        }
        private string username;

        public string User_Name
        {
            get { return username; }
            set { username = value; }
        }

        private DateTime datetaken;

        public DateTime DateTaken
        {
            get { return datetaken; }
            set { datetaken = value; }
        }

        

        private float total_price;

        public float Total_Prices
        {
            get { return total_price; }
            set { total_price = value; }
        }

    }
}
