using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Fault
    {
        #region properties:
        public int numberFault { get; set; }
        public int numberCar { get; set; }
        public int numberCall { get; set; }
        public DateTime dateOfFault { get; set; }
        public TybeFault typeFault = new TybeFault();
        public bool isWear { get; set; }
        public int priceOfFault { get; set; }
        public string garageOfFix { get; set; }
        #endregion
        #region to string:
        public override string ToString()
        {
            return string.Format("number car of fault: {0},date of fault: {1},price: {2};garage of fix it: {3}", numberCar, dateOfFault, priceOfFault, garageOfFix);
        }
        #endregion
    }
}


