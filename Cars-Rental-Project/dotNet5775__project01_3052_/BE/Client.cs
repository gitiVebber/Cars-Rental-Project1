using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Client
    {
        public int IDClient { get; set; }
        public string adressClient { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string creditCerd { get; set; }
        public DateTime ValidityCreditCerd { set; get; }
        public string CVV { set; get; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string Email { set; get; }
        public string Telephone { set; get; }
        public string Celephone { set; get; }
       
        public override string ToString()
        {
            return string.Format("ID of client: {0},aderss: {1},credit cart: {2},", IDClient, adressClient, creditCerd);
        }

    }
}
