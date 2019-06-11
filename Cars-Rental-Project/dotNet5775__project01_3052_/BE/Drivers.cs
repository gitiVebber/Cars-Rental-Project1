using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  

      public  class Drivers
        {
            public int IDMainDrivers { get; set; }
            public string nameMainDrivers { get; set; }
            public int IDSubDrivers
            {
                get
                { return IDSubDrivers; }
                set
                {
                    if (value == 0)
                        IDSubDrivers = 9999999;
                }

            }
            public string nameSubDrivers { get; set; }
        }
    
}
