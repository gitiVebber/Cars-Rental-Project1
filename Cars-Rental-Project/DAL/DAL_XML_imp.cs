using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    class Dal_XML_imp : Idal
    {
        private static int numberCar = 10000000;
        private static int numberFault = 10000000;
        private static int numberRenting = 10000000;
        List<Client> clients = new List<Client>();
        XElement clientRoot;
        string clientPath = @"ClientXml.xml";
        XElement carRoot;
        string carPath = @"CarBySerilalizer.xml";
        XElement typeFaultRoot;
        string TypeFaultPath = @"TypeFaultBySerilalizer.xml";
        XElement faultRoot;
        string FaultPath = @"FaultBySerilalizer.xml";
        XElement rentingRoot;
        string RentingPath = @"RentingBySerilalizer.xml";
        XElement configRoot;
        string configPath = @"config.xml";
        #region =====constractor======
        public Dal_XML_imp()
        {
            // DataSource איתחול הרשימות מה 
            DataSource.carList = new List<Car>();
            DataSource.faultList = new List<Fault>();
            DataSource.typeFaultList = new List<TybeFault>();
            DataSource.rentingList = new List<Renting>();
            try
            {
                //קובץ עבור לקוחות
                if (!File.Exists(clientPath))
                {
                    clientRoot = new XElement("clients");
                    clientRoot.Save(clientPath);
                }
                else
                    clientRoot = XElement.Load(clientPath);
                //קובץ עבור מכוניות
                if (!File.Exists(carPath))
                {
                    carRoot = new XElement("cars");
                    carRoot.Save(carPath);
                }
                else
                {
                    carRoot = XElement.Load(carPath);
                    DataSource.carList = loadCarListFromXML(carPath);
                }
                //קובץ עברו סוגי תקלות
                if (!File.Exists(TypeFaultPath))
                {
                    typeFaultRoot = new XElement("typeFault");
                    typeFaultRoot.Save(TypeFaultPath);
                }
                else
                {
                    typeFaultRoot = XElement.Load(TypeFaultPath);
                    DataSource.typeFaultList = loadTybeFaultListFromXML(TypeFaultPath);
                }
                //קובץ עבור תקלות 
                if (!File.Exists(FaultPath))
                {
                    faultRoot = new XElement("fault");
                    faultRoot.Save(FaultPath);
                }
                else
                {
                    faultRoot = XElement.Load(FaultPath);
                    DataSource.faultList = loadFaultListFromXML(FaultPath);
                }
                //קובץ עבור הזמנות
                if (!File.Exists(RentingPath))
                {
                    rentingRoot = new XElement("rentings");
                    rentingRoot.Save(RentingPath);
                }
                else
                {
                    rentingRoot = XElement.Load(RentingPath);
                    DataSource.rentingList = loadRentingListFromXML(RentingPath);
                }
                //קובץ עבור המספרים הרצים
                if (!File.Exists(configPath))
                {
                    configRoot = new XElement("configs",
                        new XElement("numberCar", numberCar),
                        new XElement("numberRenting", numberRenting),
                        new XElement("numberFault", numberFault));
                    configRoot.Save(configPath);
                }
                else
                {
                    configRoot = XElement.Load(configPath);
                    numberCar = int.Parse(configRoot.Element("numberCar").Value);
                    numberFault = int.Parse(configRoot.Element("numberFault").Value);
                    numberRenting = int.Parse(configRoot.Element("numberRenting").Value);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        #endregion

        #region של רכבים הזמנות ותקלות lode וה  save פונקציות ה serliazer פונקציות של ה
        /// <summary>
        ///פונקצית השמירה של הרכבים
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public static void saveCarListToXML(List<Car> list, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(fs, list);
            fs.Close();
        }
        /// <summary>
        /// פונקצית ההורדה של הרכבים לתוך הרשימה
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Car> loadCarListFromXML(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(List<Car>));
            List<Car> car = (List<Car>)x.Deserialize(fs);
            fs.Close();
            return car;

        }
        /// <summary>
        /// פונקצית שמירת ההזמנות
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public static void saveRentingListToXML(List<Renting> list, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(fs, list);
            fs.Close();
        }
        /// <summary>
        /// פונקצית ההורדה של ההזמנות לתוך הרשימה
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Renting> loadRentingListFromXML(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(List<Renting>));
            List<Renting> renting = (List<Renting>)x.Deserialize(fs);
            fs.Close();
            return renting;
        }
        /// <summary>
        /// פונקצית שמירת סוגי התקלות
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public static void saveTybeFaultListToXML(List<TybeFault> list, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(fs, list);
            fs.Close();
        }
        /// <summary>
        /// פונקצית ההורדה של סוגי ההזמנות לתוך הרשימה
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<TybeFault> loadTybeFaultListFromXML(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(List<TybeFault>));
            List<TybeFault> typefault = (List<TybeFault>)x.Deserialize(fs);
            fs.Close();
            return typefault;
        }
        /// <summary>
        /// פונקצית שמירת התקלות
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        public static void saveFaultListToXML(List<Fault> list, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(fs, list);
            fs.Close();
        }
        /// <summary>
        /// פונקצית הורדת התקלות לתוך הרשימה
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Fault> loadFaultListFromXML(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer x = new XmlSerializer(typeof(List<Fault>));
            List<Fault> fault = (List<Fault>)x.Deserialize(fs);
            fs.Close();
            return fault;

        }
        #endregion

        #region פונקציות הלקוחות
        /// <summary>
        /// פונקציה המחזירה לקוח לפי מספר זהות
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Client GetClient(int ID)
        {
            Client client;
            try
            {
                clientRoot = XElement.Load(clientPath);
                client = (from c in clientRoot.Elements()
                          where Convert.ToInt32(c.Element("IDClient").Value) == ID
                          select new Client()
                          {
                              IDClient = int.Parse(c.Element("IDClient").Value),
                              name = c.Element("Name").Element("firstname").Value,
                              lastName = c.Element("Name").Element("lastname").Value,
                              codeTelephone = c.Element("telephon").Element("codeTelephon").Value,
                              numTelephone = c.Element("telephon").Element("numTelephon").Value,
                              codePelePhone = c.Element("telephon").Element("codePelephon").Value,
                              numPelePhone = c.Element("telephon").Element("numTelephon").Value,
                              addressClient = c.Element("address").Value,
                              Email = c.Element("email").Value,
                              dateOf = Convert.ToDateTime(c.Element("dateOfLicense").Value),
                              dateOfBirth = Convert.ToDateTime(c.Element("dateOfBirs").Value),
                              creditCerd = c.Element("creditCardInformation").Element("creditCerd").Value,
                              CVV = c.Element("creditCardInformation").Element("CVV").Value,
                              validity = Convert.ToDateTime(c.Element("creditCardInformation").Element("validity").Value),
                          }
                    ).FirstOrDefault();

            }
            catch (Exception)
            {
                client = null;
            }
            return client;

        }
        /// <summary>
        ///XML פונקציה המוסיפה לקוח לקובץ 
        /// </summary>
        /// <param name="client1"></param>
        public void addClient(Client client1)
        {

            Client c = GetClient(client1.IDClient);
            if (c == null)
            {
                XElement client = new XElement("client",
                        new XElement("IDClient", client1.IDClient),
                        new XElement("Name",
                            new XElement("firstname", client1.name),
                            new XElement("lastname", client1.lastName)),
                        new XElement("telephon",
                            new XElement("codeTelephon", client1.codeTelephone),
                            new XElement("numTelephon", client1.numTelephone),
                            new XElement("codePelephon", client1.codePelePhone),
                            new XElement("numPelephon", client1.numPelePhone)),
                        new XElement("address", client1.addressClient),
                        new XElement("email", client1.Email),
                        new XElement("dateOfLicense", client1.dateOf),
                        new XElement("dateOfBirs", client1.dateOfBirth),
                        new XElement("creditCardInformation",
                            new XElement("creditCerd", client1.creditCerd),
                            new XElement("CVV", client1.CVV),
                            new XElement("validity", client1.validity)));

                clientRoot.Add(client);
                clientRoot.Save(clientPath);
            }
            else
                throw new Exception("this client existing");

        }
        /// <summary>
        /// פונקציה המוחקת לקוח לפי מספר זהות
        /// </summary>
        /// <param name="ID"></param>
        public void removeClient(int ID)
        {
            XElement clientElement;
            try
            {
                clientElement = (from item in clientRoot.Elements()
                                 where Convert.ToInt32(item.Element("IDClient").Value) == ID
                                 select item).FirstOrDefault();
                clientElement.Remove();
                clientRoot.Save(clientPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// פונקציה המעדכנת לקוח
        /// </summary>
        /// <param name="c"></param>
        public void updateClient(Client c)
        {
            XElement clientElement = (from item in clientRoot.Elements()
                                      where Convert.ToInt32(item.Element("IDClient").Value) == c.IDClient
                                      select item).FirstOrDefault();
            if (clientElement != null)
            {
                clientElement.Element("telephon").Element("codeTelephon").Value = c.codeTelephone;
                clientElement.Element("telephon").Element("numTelephon").Value = c.numTelephone;
                clientElement.Element("telephon").Element("codePelephon").Value = c.codePelePhone;
                clientElement.Element("telephon").Element("numPelephon").Value = c.numPelePhone;
                clientElement.Element("address").Value = c.addressClient;
                clientElement.Element("email").Value = c.Email;
                clientElement.Element("creditCardInformation").Element("creditCerd").Value = c.creditCerd;
                clientElement.Element("creditCardInformation").Element("CVV").Value = c.CVV;
                clientElement.Element("creditCardInformation").Element("validity").Value = Convert.ToString(c.validity);
                clientRoot.Save(clientPath);
            }

        }
        /// <summary>
        ///XML פונקציה המחזירה את כל רשימת הלקוחות מהקובץ 
        /// </summary>
        /// <returns></returns>
        public List<Client> getAllClients()
        {
            clientRoot = XElement.Load(clientPath);

            try
            {
                clients = (from c in clientRoot.Elements()
                           select new Client()
                           {
                               IDClient = int.Parse(c.Element("IDClient").Value),
                               name = c.Element("Name").Element("firstname").Value,
                               lastName = c.Element("Name").Element("lastname").Value,
                               codeTelephone = c.Element("telephon").Element("codeTelephon").Value,
                               numTelephone = c.Element("telephon").Element("numTelephon").Value,
                               codePelePhone = c.Element("telephon").Element("codePelephon").Value,
                               numPelePhone = c.Element("telephon").Element("numTelephon").Value,
                               addressClient = c.Element("address").Value,
                               Email = c.Element("email").Value,
                               dateOf = Convert.ToDateTime(c.Element("dateOfLicense").Value),
                               dateOfBirth = Convert.ToDateTime(c.Element("dateOfBirs").Value),
                               creditCerd = c.Element("creditCardInformation").Element("creditCerd").Value,
                               CVV = c.Element("creditCardInformation").Element("CVV").Value,
                               validity = Convert.ToDateTime(c.Element("creditCardInformation").Element("validity").Value),
                           }).ToList();
            }
            catch (Exception)
            {
                clients = null;
            }
            return clients;
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
                configRoot.Element("numberCar").Value = Convert.ToString(numberCar);
                configRoot.Save(configPath);
                saveCarListToXML(DataSource.carList, carPath);
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
            saveCarListToXML(DataSource.carList, carPath);
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
                saveCarListToXML(DataSource.carList, carPath);
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
            saveCarListToXML(DataSource.carList, carPath);
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
                    saveTybeFaultListToXML(DataSource.typeFaultList, TypeFaultPath);
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
                configRoot.Element("numberFault").Value = Convert.ToString(numberFault);
                configRoot.Save(configPath);
            }
            Fault f = GetFault(fault.numberFault);
            if (f != null)
                throw new Exception("this fault is already at the system");
            else
                DataSource.faultList.Add(fault);
            saveFaultListToXML(DataSource.faultList, FaultPath);

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
            saveFaultListToXML(DataSource.faultList, FaultPath);
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
            Client c2 = GetClient(r.drivers.IDSubDrivers);
            if (c == null || c1 == null)
                throw new Exception("Unable to make a reservation with a car or clients not exist");
            r.numberCall = numberRenting++;
            configRoot.Element("numberRenting").Value = Convert.ToString(numberRenting);
            configRoot.Save(configPath);
            DataSource.rentingList.Add(r);
            saveRentingListToXML(DataSource.rentingList, RentingPath);
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
            saveRentingListToXML(DataSource.rentingList, RentingPath);
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
            saveRentingListToXML(DataSource.rentingList, RentingPath);

        }
        public List<Renting> getAllRentings()
        {
            return DataSource.rentingList;
        }
        #endregion

        /// <summary>
        /// DISTRACTOR - xml שמירת כל קבצי ה
        /// </summary>
        ~Dal_XML_imp()
        {
            saveCarListToXML(DataSource.carList, carPath);
            saveFaultListToXML(DataSource.faultList, FaultPath);
            saveTybeFaultListToXML(DataSource.typeFaultList, TypeFaultPath);
            saveRentingListToXML(DataSource.rentingList, RentingPath);
            clientRoot.Save(clientPath);
            configRoot.Save(configPath);
        }
    }
}
