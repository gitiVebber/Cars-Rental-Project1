using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Fault
    {
        public int numberFault { get; set; }
        public int numberCar { get; set; }
        public int numbetCall { get; set; }
        public DateTime dateOfFault { get; set; }
        public TybeFault tybeFault = new TybeFault();
        public bool isWear { get; set; }
        public int priceOfFault { get; set; }
        public string garageOfFix { get; set; }
        public override string ToString()
        {
            return string.Format("number car of fault: {0},date of fault: {1},price: {2};garage of fix it: {3}", numberCar, dateOfFault, priceOfFault, garageOfFix);
        }
    }
}
