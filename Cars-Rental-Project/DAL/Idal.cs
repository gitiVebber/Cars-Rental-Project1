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
        void updateClient(Client c);
        Client GetClient(int ID);

        void addCar(Car car);
        void removeCar(string licensePlate);
        void updateCar(Car car);

        void addFaultForCar(string licensePlate, Fault fault);
        Car GetCar(string licensePlate);
        void addTypeFault(TybeFault t);
        void addrenting(Renting r);
        void renoveRenting(int renting);
        void updateRenting(Renting renting);
        Renting GetRenting(int rentingCall);

        TybeFault getTybeFault(string num);
        TybeFault getTybeFault(int num);
        List<TybeFault> getAllTypeFaults();
        void addFault(Fault fault);
        void removeFault(int fault);
        void updateFault(int fault);
        Fault GetFault(int fault);

        List<Client> getAllClients();
        List<Car> getAllCars();
        List<Renting> getAllRentings();
        List<Fault> getAllFaults();


    }
}
