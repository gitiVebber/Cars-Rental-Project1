using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   
   public class Renting
    {
        #region properties:
        public int numberCall { get; set; }
        public DateTime StartRenting { get; set; }
        public DateTime endRenting { get; set; }
        public Drivers drivers = new Drivers();
        public string licensePlate { get; set; }
        public int sumDrivers { get; set; }
        public int startKM { get; set; }
        public int KM { get; set; }
        public bool isFault { get; set; }
        public TybeFault t = new TybeFault();
        public int price { get; set; }
        public bool isGPS { get; set; }
        public int chairBaby { get; set; }
        public int chairChild { get; set; }
        public string insurance { get; set; }
        public bool finishRenting { get; set; }
        #endregion
        #region to string:        
        public override string ToString()
        {
            return string.Format(""+ numberCall);
        }
        #endregion
    }
}
