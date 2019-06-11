using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Client
    {
        #region properties:
        public int IDClient { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string codeTelephone { get; set; }
        public string numTelephone { get; set; }
        public string codePelePhone { get; set; }
        public string numPelePhone { get; set; }
        public string addressClient { get; set; }
        public string Email { get; set; }
        public DateTime dateOf { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string creditCerd { get; set; }
        public string CVV { get; set; }
        public DateTime validity { get; set; }
        #endregion

        #region to string:
        public override string ToString()
        {
            return string.Format("" + IDClient);
        }
        #endregion
    }
}
