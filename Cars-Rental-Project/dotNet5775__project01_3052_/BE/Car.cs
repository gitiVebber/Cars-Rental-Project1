using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Car
    {
       public string LicensePlate { get; set; }
        public int numberCar { get; set; }
        public DateTime dateLicensed { get; set; }
        public DateTime creatureCar { get; set; }
        public TybeCar tybeCar = new TybeCar();
        public automat isAutomat { get; set; }
        public int sumTravelers { get; set; }
        public int sumDoors { get; set; }
        public int KM { get; set; }
        public string adressBranch { get; set; }
        public List<Fault> faults { get; set; }
        public Car()
        {
            faults = new List<Fault>();
        }
        public override string ToString()
        {
            return string.Format("Number Car: {0},tybe Car: {1},adress of Branch {2},list of faults{3}", numberCar, tybeCar, adressBranch, faults);
        }
    }
}
