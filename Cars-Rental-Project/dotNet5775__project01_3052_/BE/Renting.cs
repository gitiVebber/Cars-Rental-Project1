using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   
   public class Renting
    {

        public int numberCall { get; set; }
        public DateTime StartRenting { get; set; }
        public DateTime endRenting { get; set; }
        public Drivers drivers = new Drivers();
       // public int numCar { get; set; }
        public string licensePlate { get; set; }
        public int sumDrivers { get; set; }
        public int startKM { get; set; }
        public int KM { get; set; }
        public bool isFault { get; set; }
        public int price { get; set; }
        public override string ToString()
        {
            return string.Format("numberCall:{0},date start renting :{1},date start renting :{2},price: {3}", numberCall, StartRenting, endRenting, price);
        }
    }
}
