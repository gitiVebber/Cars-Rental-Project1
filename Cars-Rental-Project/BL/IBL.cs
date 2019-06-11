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
        void updateClient(Client c);
        Client GetClient(int ID);
       
        void addCar(Car car);
        void removeCar(string numberCar);
        void updateCar(Car car);
        void addFaultForCar(string car, Fault fault);
        Car GetCar(string NumberCar);

        void addrenting(Renting r);
        void renoveRenting(int renting);
        void updateRenting(Renting renting);
        Renting GetRenting(int rentingCall);
        void addTypeFault(TybeFault t);
        void addFault(Fault fault);
        void removeFault(int fault);
        void updateFault(int fault);
        Fault GetFault(int fault);
  
        TybeFault getTybeFault(string num);
        TybeFault getTybeFault(int num);
        List<Client> getAllClients();
        List<Car> getAllCars();
        List<Renting> getAllRentings();
        List<Fault> getAllFaults();
        List<TybeFault> getAllTypeFaults();

        List<Renting> getRentings(int Client);
        List<TybeFault> getFaultSorting();
        List<Renting> getAllrentingsForClientBeetweenDates(int ID, DateTime Start, DateTime finish);
        int getCostForClient(int ID);
        int getCostForClient1(int ID, DateTime Start, DateTime finish);
        int getAllspace();
        int endRenting(Renting r);
       
        bool thisClientIsFault(int c);
        List<Car> getAllCarsByPredicate(Predicate<Car> c);
        List<Renting> getAllRentingByPredicate(Predicate<Renting> r);
        List<Client> getAllClientsByPredicate(Predicate<Client> c);
        List<Fault> getAllFaultsByPredicate(Predicate<Fault> f);
        List<Car> isAutomaton();
        IEnumerable<object> sumAll();
        bool newDriver(int id);
        List<Renting> getAllRentingToEnd();
    }
}
