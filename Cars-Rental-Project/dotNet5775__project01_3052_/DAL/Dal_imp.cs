using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
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
            
        }

        public void addClient(Client client)
        {
            Client clien = GetClient(client.IDClient);
            if (clien != null)
                throw new Exception("this client is already at the system");
            DataSource.clientList.Add(client);
            throw new Exception("ok!!");
        }
        public Client GetClient(int ID)
        {
            return DataSource.clientList.FirstOrDefault(s => s.IDClient == ID);
        }
        public void removeClient(int ID)
        {
            Client clien = GetClient(ID);
            if (clien == null)
                throw new Exception("not find this client to remove");
            DataSource.clientList.Remove(clien);
            throw new Exception("ok!!");
        }
        public void updateClient(int Client)
        {
            Client c = GetClient(Client);
            if (c == null)
                throw new Exception("not find this client to update");
            else
            {
                Console.WriteLine("enter the address to update");
                string adress = Console.ReadLine();
                c.adressClient = adress;
                Console.WriteLine("enter the num card to update");
                string card = Console.ReadLine();
                c.creditCerd =card;
                throw new Exception("ok!!");

            }
        }

        public Car GetCar(string licensePlate)
        {
            return DataSource.carList.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }
        public void addCar(Car car)
        {
           // if (car.numberCar == 0)
           // {
               // car.numberCar = numberCar;
               // numberCar++;

           // }
            Car c = GetCar(car.LicensePlate);
            if (c != null)
                throw new Exception("this car is already at the system");
            else{
                car.numberCar=numberCar++;
            DataSource.carList.Add(car);
            //throw new Exception("ok!!");
                }

        }
        public void removeCar(string licensePlate)
        {
            Car c = GetCar(licensePlate);
            if (c == null)
                throw new Exception("not find this car to remove");
            DataSource.carList.Remove(c);
            throw new Exception("ok!!");
        }
        public void updateCar(Car car)
        {
            Car c = GetCar(car.LicensePlate);
            if (c == null)
                throw new Exception("not find this numberCar");
            else
            {
              //  Console.WriteLine("enter km to update");
                int k = int.Parse(Console.ReadLine());
                c.KM = k;
            }

        }
        public void addFaultForCar(string licensePlate, int fault)
        {
            Car c = GetCar(licensePlate);
            if (c == null)
                throw new Exception("not find this numberCar");

            Fault f = GetFault(fault);
            if (f == null)
                throw new Exception("this fault is Not available, pleasa add this fault" );
           
            c.faults.Add(f);
            throw new Exception("ok!!");

        }

        public Renting GetRenting(int renting)
        {
            return DataSource.rentingList.FirstOrDefault(r => r.numberCall == renting);
        }
        public void addrenting(string licensePlate, int IDClient)
        {
            Renting r = new Renting();
            //if (r != null)
            //    throw new Exception("this renting is already at the system");
            r.numberCall = numberRenting++;
            r.drivers.IDMainDrivers = IDClient;
            r.licensePlate= licensePlate;
           
            DataSource.rentingList.Add(r);
            throw new Exception("ok!!\n your number renting is"+r.numberCall);
        }
        public void renoveRenting(int renting)
        {
            Renting r = GetRenting(renting);
            if (r == null)
                throw new Exception("not find this renting to remove");
            DataSource.rentingList.Remove(r);

            throw new Exception("ok!!");
        }
        public void updateRenting(int renting)
        {
            Renting r = GetRenting(renting);
            if (r == null)
                throw new Exception("not find this number renting ");
            Console.WriteLine("enter time of start and of end renting");
            DateTime Start, end;
            Start = DateTime.Parse(Console.ReadLine());
            end = DateTime.Parse(Console.ReadLine());
            r.StartRenting = Start;
            r.endRenting = end;

            throw new Exception("ok!!");
        }

        public Fault GetFault(int fault)
        {
            return DataSource.faultList.FirstOrDefault(f => f.numberFault == fault);
        }
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
        public void removeFault(int fault)
        {
            Fault f = GetFault(fault);
            if (f == null)
                throw new Exception("not find this fault to remove");
            else
                DataSource.faultList.Remove(f);
            throw new Exception("ok!!");
        }
        public void updateFault(int fault)
        {
            Fault f = GetFault(fault);
            if (f == null)
                throw new Exception("this fault is not find to update");
            Console.WriteLine("enter the price to update");
            int p = int.Parse(Console.ReadLine());
            f.priceOfFault = p;
            throw new Exception("ok!!");

        }
        public List<Client> getAllClients()
        {
            return DataSource.clientList;
        }
        public List<Car> getAllCars()
        {
            return DataSource.carList;
        }
        public List<Renting> getAllRentings()
        {
            return DataSource.rentingList;
        }
        public List<Fault> getAllFaults()
        {
            return DataSource.faultList;
        }
    }
}

