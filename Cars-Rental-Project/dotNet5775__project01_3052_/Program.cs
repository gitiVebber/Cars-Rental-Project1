//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
////using DAL;
//using BE;
//namespace dotNet5775__project01_3052_
//{
//    class Program
//    {
//        static BL.IBL d;
//        static Program()
//        {

//            d = BL.FactoryBL.getBL();
//        }
//        static void Main(string[] args)
//        {
//            int choice, chocic2, num, x;
//            Car car;
//            do
//            {
//                Console.WriteLine("enter:");
//                Console.WriteLine("1-cars");
//                Console.WriteLine("2-faults");
//                Console.WriteLine("3-renrings");
//                Console.WriteLine("4-clients");

//                choice = int.Parse(Console.ReadLine());
//                switch (choice)
//                {   
//                    case 1:
//                        Console.WriteLine("enter:");
//                        Console.WriteLine("1-to add");
//                        Console.WriteLine("2-to remove");
//                        Console.WriteLine("3-to update");
//                        Console.WriteLine("4-add for a sfesific car a fault");
//                        chocic2 = int.Parse(Console.ReadLine());
//                        switch (chocic2)
//                        {
//                            case 1:
//                                Console.WriteLine("add number car");
//                                num = int.Parse(Console.ReadLine());
//                                car = new Car { numberCar = num };
//                                try
//                                {
//                                    d.addCar(car);
//                                }
//                                catch (Exception e)
//                                {

//                                    Console.WriteLine(e.Message);
//                                }

//                                break;
//                            case 2:
//                                Console.WriteLine("enter numbercar to remove");
//                                num = int.Parse(Console.ReadLine());
//                                try
//                                {
//                                    d.removeCar(num.ToString());
//                                }
//                                catch (Exception e)
//                                {

//                                    Console.WriteLine(e.Message);
//                                }

//                                break;
//                            case 3:
//                                Console.WriteLine("enter numbercar to uptade");
//                                num = int.Parse(Console.ReadLine());

//                                try
//                                {
//                                    d.updateCar(num);
//                                }
//                                catch (Exception e)
//                                {

//                                    Console.WriteLine(e.Message);
//                                }
//                                break;
//                            case 4:
//                                Console.WriteLine("enter num car to add fault");
//                                num = int.Parse(Console.ReadLine());
//                                Console.WriteLine("enter num fault to add");
//                                x = int.Parse(Console.ReadLine());

//                                try
//                                {
//                                    d.addFaultForCar(num, x);
//                                }
//                                catch (Exception e)
//                                {

//                                    Console.WriteLine(e.Message);
//                                }
//                                break;

//                        }
//                        break;
//                    case 2:
//                        {
//                            Console.WriteLine("enter:");
//                            Console.WriteLine("1-to add");
//                            Console.WriteLine("2-to remove");
//                            Console.WriteLine("3-to update");
//                            Fault f;
//                            chocic2 = int.Parse(Console.ReadLine());
//                            switch (chocic2)
//                            {
//                                case 1:
//                                    Console.WriteLine("add number fault");
//                                    num = int.Parse(Console.ReadLine());
//                                    f = new Fault { numberFault = num };
//                                    try
//                                    {
//                                        d.addFault(f);
//                                    }
//                                    catch (Exception e)
//                                    {

//                                        Console.WriteLine(e.Message);
//                                    }

//                                    break;
//                                case 2:
//                                    Console.WriteLine("enter numbercar to remove");
//                                    num = int.Parse(Console.ReadLine());
//                                    try
//                                    {
//                                        d.removeFault(num);
//                                    }
//                                    catch (Exception e)
//                                    {

//                                        Console.WriteLine(e.Message);
//                                    }

//                                    break;
//                                case 3:
//                                    Console.WriteLine("enter number fault to uptade");
//                                    num = int.Parse(Console.ReadLine());

//                                    try
//                                    {
//                                        d.updateFault(num);
//                                    }
//                                    catch (Exception e)
//                                    {
//                                        Console.WriteLine(e.Message);
//                                    }
//                                    break;
//                            }
//                        }
//                        break;

//                    case 3:
//                        {
//                            Console.WriteLine("enter:");
//                            Console.WriteLine("1-to add");
//                            Console.WriteLine("2-to remove");
//                            Console.WriteLine("3-to update");
//                            chocic2 = int.Parse(Console.ReadLine());
//                            switch (chocic2)
//                            {
//                                case 1:
//                                    Console.WriteLine("add number car ");
//                                  int  numCar = int.Parse(Console.ReadLine());
//                                     Console.WriteLine("add id client ");
//                                   int IDClient = int.Parse(Console.ReadLine());
//                                    //r = new Renting { numCar = num };
//                                    try
//                                    {
//                                        d.addrenting( numCar, IDClient);

//                                    }
//                                    catch (Exception e)
//                                    {

//                                        Console.WriteLine(e.Message);
//                                    }

//                                    break;
//                                case 2:
//                                    Console.WriteLine("enter number renting to remove");
//                                    num = int.Parse(Console.ReadLine());
//                                    try
//                                    {
//                                        d.renoveRenting(num);
//                                    }
//                                    catch (Exception e)
//                                    {

//                                        Console.WriteLine(e.Message);
//                                    }

//                                    break;
//                                case 3:
//                                    Console.WriteLine("enter number renting to uptade");
//                                    num = int.Parse(Console.ReadLine());

//                                    try
//                                    {
//                                        d.updateRenting(num);
//                                    }
//                                    catch (Exception e)
//                                    {

//                                        Console.WriteLine(e.Message);
//                                    }
//                                    break;


//                            }

//                        }
//                        break;
//                    case 4:
//                        {
//                            Console.WriteLine("enter:");
//                            Console.WriteLine("1-to add");
//                            Console.WriteLine("2-to remove");
//                            Console.WriteLine("3-to update");
//                            Client c;
//                            chocic2 = int.Parse(Console.ReadLine());
//                            switch (chocic2)
//                            {
//                                case 1:
//                                    Console.WriteLine("add id client");
//                                    num = int.Parse(Console.ReadLine());
//                                    c = new Client { IDClient = num };
//                                    try
//                                    {
//                                        d.addClient(c);
//                                    }
//                                    catch (Exception e)
//                                    {

//                                        Console.WriteLine(e.Message);
//                                    }

//                                    break;
//                                case 2:
//                                    Console.WriteLine("enter id client to remove");
//                                    num = int.Parse(Console.ReadLine());
//                                    try
//                                    {
//                                        d.removeClient(num);
//                                    }
//                                    catch (Exception e)
//                                    {

//                                        Console.WriteLine(e.Message);
//                                    }

//                                    break;
//                                case 3:
//                                    Console.WriteLine("enter id client to uptade");
//                                    num = int.Parse(Console.ReadLine());

//                                    try
//                                    {
//                                        d.updateClient(num);
//                                    }
//                                    catch (Exception e)
//                                    {
//                                        Console.WriteLine(e.Message);
//                                    }
//                                    break;
//                            }

//                        }
//                        break;

//                }
//            } while (choice != 0);


//        }
//    }
//}
