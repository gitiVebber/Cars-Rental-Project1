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
        #region DALמימוש פונקציות ה
        public void addClient(Client client)
        {
            try
            {
                dal.addClient(client);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void removeClient(int ID)
        {
            try
            {
                if (lastRenting(ID))
                    dal.removeClient(ID);
                else
                    throw new Exception("cont remove this client");
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }
        public void updateClient( Client c)
        {
            try
            {
                dal.updateClient(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Client GetClient(int ID)
        { return dal.GetClient(ID); }

        public void addTypeFault(TybeFault t)
        {
            try
            {
                dal.addTypeFault(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       public TybeFault getTybeFault(string name)
        { return dal.getTybeFault(name); }
      public  TybeFault getTybeFault(int num)
        { return dal.getTybeFault(num); }

        public void addCar(Car car)
      {
          try
          {
              dal.addCar(car);
          }
          catch (Exception e)
          {
              throw e;
          }
        }
        public void removeCar(string numberCar)
        {
            try
            {
                var v = from item in getAllRentings()
                        where item.licensePlate == numberCar
                        select item;
                DateTime d = DateTime.Now;
                foreach (var item in v)
                {
                    if (item.endRenting > d)
                    {
                        throw new Exception("This car is still rented");
                    }
                }
                dal.removeCar(numberCar);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void updateCar(Car car)
        {
            try
            {
                dal.updateCar(car);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void addFaultForCar(string car, Fault fault)
        {
            try
            {
                dal.addFaultForCar(car, fault);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Car GetCar(string NumberCar)
        { return dal.GetCar(NumberCar); }


        public void addrenting(Renting r)
        {
            try
            {
                if (dal.GetCar(r.licensePlate) != null && dal.GetClient(r.drivers.IDMainDrivers) != null)
                {
                    IEnumerable<Renting> x = isFault(r.drivers.IDMainDrivers);
                    if (thisClientIsFault(r.drivers.IDMainDrivers))

                        dal.addrenting(r);
                    else
                        throw new Exception("cont renting for this client");
                }
                else
                    throw new Exception("not find this infromasion");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void renoveRenting(int renting)
        {
            try
            {
                dal.renoveRenting(renting);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void updateRenting(Renting renting)
        {
            try
            {
                dal.updateRenting(renting);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Renting GetRenting(int rentingCall)
        { return dal.GetRenting(rentingCall); }


        public void addFault(Fault fault)
        {
            try
            {
                dal.addFault(fault);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void removeFault(int fault)
        {
            try
            {
                dal.removeFault(fault);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void updateFault(int fault)
        {
            try
            {
                dal.updateFault(fault);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
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
        public List<TybeFault> getAllTypeFaults()
        { return dal.getAllTypeFaults(); }
        #endregion

        #region  BLפונקציות שנוספו ב
        /// <summary>
        /// פונקציה המחזירה את כל ההזמנות שעדיין לא סימו אותן מבחינת תשלום ולא מבחינת תאריך
        /// </summary>
        /// <returns></returns>
        public List<Renting> getAllRentingToEnd()
        {
            return(from item in getAllRentings()
                    where item.finishRenting==false//end renting משתנה עזר שמתעדכן ברגע שמפעילים
                    select item).ToList();
        
        }
        /// <summary>
        /// פונקציה המחזירה את כל הרכבים העונות על פרדיקט מסוים
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<Car> getAllCarsByPredicate(Predicate<Car> c)
        {
            IEnumerable<Car> all = from item in getAllCars()
                                   where c(item)
                                   select item;
            return all.ToList();
        }
        /// <summary>
        ///פונקציה המחזירה את כל ההזמנות העונות על פרדיקט מסוים 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<Renting> getAllRentingByPredicate(Predicate<Renting> r)
        {
            IEnumerable<Renting> all = from item in getAllRentings()
                                       where r(item)
                                       select item;
            return all.ToList();
        }
        /// <summary>
        /// פונקציה המחזירה את כל הלקוחות העונות על פרדיקט מסוים
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<Client> getAllClientsByPredicate(Predicate<Client> c)
        {
            IEnumerable<Client> all = from item in getAllClients()
                                      where c(item)
                                      select item;
            return all.ToList();

        }
        /// <summary>
        /// פונקציה המחזירה את כל התקלות העונות על פרדיקט מסוים
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public List<Fault> getAllFaultsByPredicate(Predicate<Fault> f)
        {
            IEnumerable<Fault> all = from item in getAllFaults()
                                     where f(item)
                                     select item;
            return all.ToList();
        }
        /// <summary>
        /// פונקציה הבודקת האם עברו 30 יום מסיום ההזמנה
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool lastRenting(int id)
        {
            var ren = from r in dal.getAllRentings()
                    where r.drivers.IDMainDrivers == id
                    orderby r.endRenting descending
                    select r;
            foreach (var item in ren)
            {
            DateTime t = DateTime.Now;
            DateTime t2 = item.endRenting;
            t2.AddDays(30);
            if (t2 < t&&(!item.finishRenting))
                return false;
            }

            return true;
        }
        /// <summary>
        /// פונקציה המחזירה את כל הרכבים האוטומטיים
        /// </summary>
        /// <returns></returns>
        public List<Car> isAutomaton()
        {
            IEnumerable<Car> c = from item in getAllCars()
                                 where item.isAutomat == 0
                                 select item;
            return c.ToList();
        }

        public List<Renting> isFault(int IDClient)
        {
            IEnumerable<Renting> sumFaults = (from c in dal.getAllRentings()
                                              where c.drivers.IDMainDrivers == IDClient && c.isFault == true
                                              select c);
            return sumFaults.ToList();
        }
      /// <summary>
      ///&&& פונקציה שמחשבת את כל הרווחים עבור כל רכב
      /// </summary>
      /// <returns></returns>
        public IEnumerable<object> sumAll()
        {
            var result = (from renting in dal.getAllRentings()
                          group renting by renting.licensePlate into gropCar
                          select gropCar);

            return (from r in result
                    let profic = r.Sum(s => s.price)
                    select new { num = r.Key, profit = profic  }).ToList();
        }
        /// <summary>
        /// פונקציה המחזירה אמת אם הלקוח היה מעורב בשתי הזמנות עם תקלות או יותר
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
        public List<Renting> getRentings(int ID)
        {
            return (from renting in dal.getAllRentings()
                    where renting.drivers.IDMainDrivers == ID ||renting.drivers.IDSubDrivers==ID
                    select renting).ToList<Renting>();



        }
        /// <summary>
        /// החזרת שמות התקלות בסדר ממוין לפי השכיחות
        /// </summary>
        /// <returns></returns>
        public List<TybeFault> getFaultSorting()
        {
            IEnumerable<IGrouping<TybeFault, TybeFault>> result = (from fault in dal.getAllFaults()
                                                            group fault.typeFault by fault.typeFault into g
                                                            orderby g.Count() descending
                                                            select g);
            List<TybeFault> t = new List<TybeFault>();
            foreach (var item in result)
            {
                t.Add(item.Key);
            }
            return t;

        }
        /// <summary>
        /// פונקציה לחישוב כל העלויות של ההזמנות שנעשו ע"י לקוח מסוים
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public int getCostForClient(int ID)
        {
            int sum = 0;
            Client c = new Client { IDClient = ID };
            foreach (var item in getRentings(c.IDClient))
            {
                
                sum += item.price;
            }
            return sum;

        }
        /// <summary>
        /// פונקציה לחישוב כל העלויות של ההזמנות שנעשו ע"י לקוח מסוים בין תאריכים מסוימים
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public int getCostForClient1(int ID, DateTime Start, DateTime finish)
        {
           
         IEnumerable<int> profit = from item in getAllRentings()
                       where (item.drivers.IDMainDrivers == ID || item.drivers.IDSubDrivers == ID)&&
                       item.StartRenting.Date>Start &&item.endRenting.Date<finish
                       select item.price;
            
          return profit.Sum();

        }
        /// <summary>
        /// פונקציה המחזירה את כל ההזמנות ללקוח מסוים בין שני תאריכים מסוימים
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public List<Renting> getAllrentingsForClientBeetweenDates(int ID, DateTime Start, DateTime finish)
        {

            return (from item in getAllRentings()
                    where (item.drivers.IDMainDrivers == ID || item.drivers.IDSubDrivers == ID) &&
                    item.StartRenting.Date > Start && item.endRenting.Date < finish
                    select item).ToList<Renting>();
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
               // time = item.endRenting - item.StartRenting;
               // sum += 100 * time.Days;
                sum += item.price;
            }
            
            return sum;
        }
        /// <summary>
        /// פונקציה לחישוב עלות ההזמנה בסיום ההזמנה לפי תאריך התחלה וסיום 
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
                else
                    price += 150 * day;
                price += 100 * day;
            }
            else
                price += 200 * day;
            if (r.insurance=="comprehensive")
            {
                price += 500;
            }
            if (r.insurance=="handicap insurance")
            {
                price += 250;
            }
            r.price += price;
            r.finishRenting = true;
            return price;
        }      
        /// <summary>
        /// פונקציה הבודקת האם הנהג הוא נהג חדש כלומר עדיין לא עברו שנתיים מאז קבלת הרשיון
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool newDriver(int id)
        {
            Client c = GetClient(id);
            DateTime d = new DateTime(2013, 1, 6);
            if (c.dateOf > d)
                return true;
            return false;
        }
        #endregion
    }
}
