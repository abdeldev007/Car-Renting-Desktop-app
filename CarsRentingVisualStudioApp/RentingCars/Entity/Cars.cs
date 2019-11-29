using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingCars.Entity
{
    class Cars
    {
        private int id_Car;

        public int ID_CAR
        {
            get { return id_Car; }
            set { id_Car = value; }
        }

        private string model_car;

        public string MODEL_CAR
        {
            get { return model_car; }
            set { model_car = value; }
        }

        private string mark;

        public string MARK
        {
            get { return mark; }
            set { mark = value; }
        }
 
        
        private bool available;
        public bool AVAILABLE
        {
            get { return available; }
            set { available = value; }
        }

        private string imageUrl;
        public string IMAGE_URL
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }


        private float priceForAday;
        public float PRICE_FOR_DAY
        {
            get { return priceForAday; }
            set { priceForAday = value; }
        }

    }
}
