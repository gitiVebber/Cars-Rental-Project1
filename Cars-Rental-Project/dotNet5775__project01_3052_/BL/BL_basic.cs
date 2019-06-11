using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace BL
{
    public class BL_basic : IBL
    {
        DAL.Idal dal = DAL.Factory.getDAL();

        public void addClient(Client client)
        { dal.addClient(client); }
        public void removeClient(int ID)
        {
            if(lastRenting(ID))
            dal.removeClient(ID);
            else
                throw new Exception("cont remove this client");
        }
        public void updateClient(int Client)
        { dal.updateClient(Client); }
        public Client GetClient(int ID)
        { return dal.GetClient(ID); }


        public void addCar(Car car)
        {
            //try
            //{
                dal.addCar(car);
            //}
            //catch (Exception)
            //{ 
            
           // }
        }
        public void removeCar(string numberCar)
        { dal.removeCar(numberCar); }
        public void updateCar(Car car)
        { dal.updateCar(car); }
        public void addFaultForCar(string car, int fault)
        { dal.addFaultForCar(car, fault); }
        public Car GetCar(string NumberCar)
        { return dal.GetCar(NumberCar); }


        public void addrenting(string numCar, int IDClient)
        {
            if (dal.GetCar(numCar) != null && dal.GetClient(IDClient) != null)
            {
                IEnumerable<Renting> x = isFault(IDClient);
                if (thisClientIsFault(IDClient))

                    dal.addrenting(numCar, IDClient);
                else
                    throw new Exception("cont renting for this client");
            }
            else
                throw new Exception("not find this infromasion");

        }
        public void renoveRenting(int renting)
        { dal.renoveRenting(renting); }
        public void updateRenting(int renting)
        { dal.updateRenting(renting); }
        public Renting GetRenting(int rentingCall)
        { return dal.GetRenting(rentingCall); }


        public void addFault(Fault fault)
        { dal.addFault(fault); }
        public void removeFault(int fault)
        { dal.removeFault(fault); }
        public void updateFault(int fault)
        { dal.updateFault(fault); }
        public Fault GetFault(int fault)
        { return dal.GetFault(fault); }


        public List<Client> getAllClients()
        { return dal.getAllClients(); }
        public List<Car> getAllCars()
        { return dal.getAllCars(); }
        public List<Renting> getAllRentings()
        { return dal.getAllRentings(); }
        public List<Fault> getAllFaults()
        { return dal.getAllFaults(); }


        public IEnumerable<Drivers> isDriveMore100KM()
        {
            List<Renting> clients = dal.getAllRentings();
            IEnumerable<Renting> a = clients.FindAll(s => s.KM > 100);
            IEnumerable<Drivers> c = a.Select(d => d.drivers);
            return c;
        }
        public IEnumerable<Drivers> isMore30Days()
        {
            List<Renting> clients = dal.getAllRentings();
            //List<Client>xx=dal.getAllClients();
            IEnumerable<Renting> c = clients.FindAll(d => d.isFault);
            IEnumerable<Drivers> xx = c.Select(d => d.drivers);


            IEnumerable<Client> r= from client  in dal.getAllClients()
                                    from renting in dal.getAllRentings()
                                    where renting.drivers.IDMainDrivers==client.IDClient && renting.isFault==true
                                    select client;


            return xx;

        }

        public bool lastRenting(int id)
        {
            Renting renting = (from r in dal.getAllRentings()
                               where r.drivers.IDMainDrivers == id
                               orderby r.endRenting descending
                               select r).FirstOrDefault();
            DateTime t = DateTime.Now;
            DateTime t2 = renting.endRenting;
            t2.AddDays(30);
            if (t2 < t)
                return false;
            return true;
        }

        public List<Renting> isFault(int IDClient)
        {
            IEnumerable<Renting> sumFaults = (from c in dal.getAllRentings()
                                              where c.drivers.IDMainDrivers == IDClient && c.isFault == true
                                              select c);
            return sumFaults.ToList();
        }
        //public int sumAllRentingsOfClient(int ID, DateTime start, DateTime end)
        //  {
        //      int sumDays = (from n in dal.getAllRentings()
        //                     where ID == n.drivers.IDMainDrivers
        //                     select new { days = n.endRenting - n.StartRenting }).Count();
        //      if (sumDays < 10)
        //          sumDays = sumDays * 150;
        //      else
        //          sumDays = sumDays * 100;

        //      return sumDays;
        //  }

        public IEnumerable<object> sumAll()
        {
            var result = (from renting in dal.getAllRentings()
                          group renting by renting.licensePlate into gropCar
                          select gropCar);

            return (from r in result
                    let profic = r.Sum(s => s.price)
                    select new { num = r.Key, profit = profic }).ToList();
        }
        public bool thisClientIsFault(int c)
        {
            var d = dal.getAllRentings().FindAll(r=>r.isFault&&r.drivers.IDMainDrivers==c);
            var f = (from renting in dal.getAllRentings()
                     where renting.drivers.IDMainDrivers == c && renting.isFault == true || renting.drivers.IDSubDrivers == c
                     select renting).Count();

            return (f < 2);

        }

        /// <summary>
        /// החזרת רשימת הזמנות ללקוח מסוים
        /// </summary>
        /// <param name="Client"></param>
        /// <returns></returns>
        public List<Renting> getRentings(Client Client)
        {
            return (from renting in dal.getAllRentings()
                    where renting.drivers.IDMainDrivers == Client.IDClient
                    select renting).ToList<Renting>();



        }
        /// <summary>
        /// החזרת שמות התקלות בסדר ממוין לפי השכיחות
        /// </summary>
        /// <returns></returns>
        public List<string> getFaultSorting()
        {
            IEnumerable<IGrouping<string, Fault>> result = (from fault in dal.getAllFaults()
                                                            group fault by fault.tybeFault.nameFault into g
                                                            select g);


            return (from item in result
                    let incidence = item.Count()
                    orderby incidence
                    select item.Key).ToList<string>();


        }

        /// <summary>
        /// פונקציה לחישוב כל העלויות של ההזמנות שנעשו ע"י לקוח מסוים
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public int getCostForClient(int ID, DateTime Start, DateTime finish)
        {
            int sum = 0;
            Client c = new Client { IDClient = ID };
            foreach (var item in getRentings(c))
            {
                sum += item.price;
            }
            return sum;

        }
        /// <summary>
        /// פונקציה לחישוב כל הרווחים עבור כל המכוניות
        /// </summary>
        /// <returns></returns>
        public int getAllspace()
        {
            int sum = 0;
            TimeSpan time;
            foreach (var item in dal.getAllRentings())
            {
                time = item.endRenting - item.StartRenting;
                sum += 100 * time.Days;
            }

            return sum;
        }

        /// <summary>
        /// פונקציה לחישוב עלות ההזמנה בסיום ההזמנה לפי תאריך התחלה וסיום כולל הוצאות עבור תיקון תקלה
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public int endRenting(Renting r)
        {
            int price = 0;
            TimeSpan time = r.endRenting - r.StartRenting;
            int day = time.Days;
            if (day >= 3)
            {
                price += 200 * 3;
                day -= 3;
                if (day >= 7)
                {
                    price += 150 * 7;
                    day -= 7;
                }
                price += 100 * day;
            }
            else
                price += 200 * day;

            if (ifFault(r))
            {
                var v = from f in dal.getAllFaults()
                        where f.numbetCall == r.numberCall
                        select f;

                foreach (var item in v)
                {
                    price += item.priceOfFault;
                }

            }
            r.price = price;
            return price;
        }
        /// <summary>
        /// פונקציה הבודקת אם היתה תקלה ברכב לפי מספר הזמנה בתוך רשימת התקלות
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool ifFault(Renting r)
        {
            List<Fault> v = (from f in dal.getAllFaults()
                             where f.numbetCall == r.numberCall
                             select f).ToList<Fault>();

            if (v == null)
            {
                r.isFault = false;
                return false;
            }

            r.isFault = true;
            return true;
        }
    }
}
