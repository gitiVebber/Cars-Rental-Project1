using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface Idal
    {
        void addClient(Client client);
        void removeClient(int ID);
        void updateClient(int Client);
         Client GetClient(int ID);
       
        void addCar(Car car);
        void removeCar(string licensePlate);
        void updateCar(Car car);
      
        void addFaultForCar(string licensePlate, int fault);
        Car GetCar(string licensePlate);
        
        void addrenting(string numCar,int IDClient);
        void renoveRenting(int renting);
        void updateRenting(int renting);
        Renting GetRenting(int rentingCall);
        
        void addFault(Fault fault);
        void removeFault(int fault);
        void updateFault(int fault);
        Fault GetFault(int fault);
        
        //  int priceFault(Fault fault);
        List<Client> getAllClients();
        List<Car> getAllCars();
        List<Renting> getAllRentings();
        List<Fault> getAllFaults();
    }
}
