using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DAL;
using BE;

namespace BL
{
    public interface IBL
    {

        void addClient(Client client);
        void removeClient(int ID);
        void updateClient(int Client);
        Client GetClient(int ID);
       

        void addCar(Car car);
        void removeCar(string numberCar);
        void updateCar(Car car);
        void addFaultForCar(string car, int fault);
        Car GetCar(string NumberCar);

        void addrenting(string numCar, int IDClient);
        void renoveRenting(int renting);
        void updateRenting(int renting);
        Renting GetRenting(int rentingCall);

        void addFault(Fault fault);
        void removeFault(int fault);
        void updateFault(int fault);
        Fault GetFault(int fault);


        List<Client> getAllClients();
        List<Car> getAllCars();
        List<Renting> getAllRentings();
        List<Fault> getAllFaults();

        IEnumerable<Drivers> isDriveMore100KM();
        IEnumerable<Drivers> isMore30Days();
       // bool thisClientIsFault(Client c);

        List<Renting> getRentings(Client Client);
        List<string> getFaultSorting();
        int getCostForClient(int ID, DateTime Start, DateTime finish);
        int getAllspace();
        int endRenting(Renting r);
        bool ifFault(Renting r);
       // bool thisClientIsFault(int c);


    }
}
