using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class TybeFault
    {
        #region properties:
        public int numberFault { get; set; }
        public string nameFault { get; set; }
        public int priceOfFault { get; set; }
        public string insurance { get; set; }
        #endregion
        #region to string:
        public override string ToString()
        {
            return string.Format("" + nameFault);
        }
        #endregion
    }

}

