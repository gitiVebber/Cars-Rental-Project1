using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    #region קונסטרקטור
    public class Dal_imp : Idal
    {
        private static int numberCar = 10000000;
        private static int numberFault = 10000000;
        private static int numberRenting = 10000000;
        public Dal_imp()
        {
            DataSource.carList = new List<Car>();
            DataSource.faultList = new List<Fault>();
            DataSource.clientList = new List<Client>();
            DataSource.rentingList = new List<Renting>();
            DataSource.typeFaultList = new List<TybeFault>();
        }
    #endregion
        #region פונקציות הלקוחות
        /// <summary>
        /// פונקציה המוסיפה לקוח לרשימת הלקוחות
        /// </summary>
        /// <param name="client"></param>
        public void addClient(Client client)
        {
            Client clien = GetClient(client.IDClient);
            if (clien != null)
                throw new Exception("this client is already at the system");
            DataSource.clientList.Add(client);
        }
        /// <summary>
        /// פונקציה המחזירה לקוח לפי מספר תעודת זהות
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Client GetClient(int ID)
        {
            return DataSource.clientList.FirstOrDefault(s => s.IDClient == ID);
        }
        /// <summary>
        /// פונקציה המוחקת לקוח לפי מספר זהות
        /// </summary>
        /// <param name="ID"></param>
        public void removeClient(int ID)
        {
            Client clien = GetClient(ID);
            if (clien == null)
                throw new Exception("not find this client to remove");
            DataSource.clientList.Remove(clien);
        }
        /// <summary>
        /// פונקציה המעדכנת לקוח קיים
        /// </summary>
        /// <param name="c"></param>
        public void updateClient(Client c)
        {
            Client client = GetClient(c.IDClient);
            if (client == null)
                throw new Exception("not find this client to update");
            //משתנים שאופשרו לעידכון
            client.addressClient = c.addressClient;
            client.creditCerd = c.creditCerd;
            client.CVV = c.CVV;
            client.validity = c.validity;
            client.numTelephone = c.numTelephone;
            client.numPelePhone = c.numPelePhone;
            client.codeTelephone = c.codeTelephone;
            client.codePelePhone = c.codePelePhone;
            client.Email = c.Email;

        }
        public List<Client> getAllClients()
        {
            return DataSource.clientList;
        }
        #endregion
        #region פונקציות הרכב
        /// <summary>
        /// פונקציה המחזירה רכב לפי מספר רכב
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        public Car GetCar(string licensePlate)
        {
            return DataSource.carList.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }
        /// <summary>
        /// פונקציה המוסיפה רכב לרשימת הרכבים
        /// </summary>
        /// <param name="car"></param>
        public void addCar(Car car)
        {
            Car c = GetCar(car.LicensePlate);
            if (c != null)
                throw new Exception("this car is already at the system");
            else
            {
                car.numberCar = numberCar++;
                DataSource.carList.Add(car);
            }

        }
        /// <summary>
        /// פונקציה המוחקת רכב מרשימת הרכבים
        /// </summary>
        /// <param name="licensePlate"></param>
        public void removeCar(string licensePlate)
        {
            Car c = GetCar(licensePlate);
            if (c == null)
                throw new Exception("not find this car to remove");
            DataSource.carList.Remove(c);
        }
        /// <summary>
        /// פונקציה המעדכנת רכב קיים
        /// </summary>
        /// <param name="car"></param>
        public void updateCar(Car car)
        {
            Car c = GetCar(car.LicensePlate);
            if (c == null)
                throw new Exception("not find this numberCar");
            else
            {
                c.KM = car.KM;
                c.dateLicensed = car.dateLicensed;
                c.tybeCar.sizeMotor = car.tybeCar.sizeMotor;
            }
        }
        /// <summary>
        /// פונקציה המוסיפה תקלה קיימת לרשימת התקלות ברכב מסוים
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="fault"></param>
        public void addFaultForCar(string licensePlate, Fault fault)
        {
            Car c = GetCar(licensePlate);
            if (c == null)
                throw new Exception("not find this numberCar");

            Fault f = GetFault(fault.numberFault);
            if (f == null)
                throw new Exception("this fault is Not available, pleasa add this fault");

            c.faults.Add(f);
        }
        /// <summary>
        /// פונקציה המחזירה את כל רשימת הרכבים
        /// </summary>
        /// <returns></returns>
        public List<Car> getAllCars()
        {
            return DataSource.carList;
        }
        #endregion
        #region  פונקציות התקלות
        #region סוג תקלה
        /// <summary>
        /// פונקציה המוסיפה סוג תקלה לרשימת סוגי התקלות
        /// </summary>
        /// <param name="t"></param>
        public void addTypeFault(TybeFault t)
        {
            TybeFault f = getTybeFault(t.numberFault);
            if (f == null)
            {
                f = getTybeFault(t.numberFault);
                if (f == null)
                {
                    DataSource.typeFaultList.Add(t);
                }
            }
            else
                throw new Exception("this type fault Available");

        }
        /// <summary>
        /// פונקציה המחזירה סוג תקלה לפי שם
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TybeFault getTybeFault(string name)
        {
            return DataSource.typeFaultList.FirstOrDefault(f => f.nameFault == name);
        }
        /// <summary>
        /// פונקציה המחזירה סוג תקלה לפי מספר
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public TybeFault getTybeFault(int num)
        {
            return DataSource.typeFaultList.FirstOrDefault(f => f.numberFault == num);
        }
        public List<TybeFault> getAllTypeFaults()
        {
            return DataSource.typeFaultList;
        }
        #endregion
        #region תקלה
        /// <summary>
        /// פונקציה המחזירה תקלה מסוימת לפי מספר תקלה
        /// </summary>
        /// <param name="fault"></param>
        /// <returns></returns>
        public Fault GetFault(int fault)
        {
            return DataSource.faultList.FirstOrDefault(f => f.numberFault == fault);
        }
        /// <summary>
        /// פונקציה המוסיפה תקלה לרשימת התקלות
        /// </summary>
        /// <param name="fault"></param>
        public void addFault(Fault fault)
        {
            if (fault.numberFault == 0)
            {
                fault.numberFault = numberFault;
                numberFault++;

            }
            Fault f = GetFault(fault.numberFault);
            if (f != null)
                throw new Exception("this fault is already at the system");
            else
                DataSource.faultList.Add(fault);

            throw new Exception("ok!!");

        }
        /// <summary>
        /// פונקציה המוחקת תקלה מרשימת התקלות
        /// </summary>
        /// <param name="fault"></param>
        public void removeFault(int fault)
        {
            Fault f = GetFault(fault);
            if (f == null)
                throw new Exception("not find this fault to remove");
            else
                DataSource.faultList.Remove(f);
            throw new Exception("ok!!");
        }
        /// <summary>
        ///פונקציה המעדכנת תקלה
        /// </summary>
        /// <param name="fault"></param>
        public void updateFault(int fault)
        {
            Fault f = GetFault(fault);
            if (f == null)
                throw new Exception("this fault is not find to update");

        }
        /// <summary>
        /// פונקציה המחזירה את כל התקלות
        /// </summary>
        /// <returns></returns>
        public List<Fault> getAllFaults()
        {
            return DataSource.faultList;
        }
        #endregion
        #endregion
        #region פונקציות ההזמנות
        public Renting GetRenting(int renting)
        {
            return DataSource.rentingList.FirstOrDefault(r => r.numberCall == renting);
        }
        public void addrenting(Renting r)
        {
            Car c = GetCar(r.licensePlate);
            Client c1 = GetClient(r.drivers.IDMainDrivers);
           
            if (c == null || c1 == null )
                throw new Exception("Unable to make a reservation with a car or clients not exist");
            r.numberCall = numberRenting++;
            DataSource.rentingList.Add(r);
            throw new Exception("ok!!\n your number renting is   " + r.numberCall);
        }
        public void renoveRenting(int renting)
        {
            Renting r = GetRenting(renting);
            if (r == null)
                throw new Exception("not find this renting to remove");
            if (r.StartRenting < DateTime.Now)
                throw new Exception("Renting already been started so can not be deleted");
            DataSource.rentingList.Remove(r);
        }
        public void updateRenting(Renting renting)
        {
            Renting r = GetRenting(renting.numberCall);
            if (r == null)
                throw new Exception("not find this number renting ");

            r.endRenting = renting.endRenting;
            r.chairBaby = renting.chairBaby;
            r.chairChild = renting.chairChild;
            r.isGPS = renting.isGPS;
            r.insurance = renting.insurance;

        }
        public List<Renting> getAllRentings()
        {
            return DataSource.rentingList;
        }
        #endregion



    }
}

