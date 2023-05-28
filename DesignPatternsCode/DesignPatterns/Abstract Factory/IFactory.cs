using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Abstract_Factory
{
    

    // Think of this class without Interface is like a factory class with what method to call properties
    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new RegularBike();
        }

        public ICar CreateCar()
        {
            return new RegularCar();
        }
    }

    // Think of this class without Interface is like a factory class with what method to call properties
    public class SportsVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new SportsBike();
        }
        public ICar CreateCar()
        {
            return new SportsCar();
        }
    }

    // Now above 2 classes have same properties and so they can be part of an Interface or called as Abstract Factory

    // The Abstract Factory interface declares a set of methods that return different abstract products. 
    // These products are called a family. 
    // A family of products may have several variants
    public interface IVehicleFactory
    {
        //Abstract Product A
        IBike CreateBike();
        //Abstract Product B
        ICar CreateCar();
    }

    #region Bike classes
    public interface IBike
    {
        void GetDetails();
    }

    public class RegularBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching RegularBike Details..");
        }
    }

    public class SportsBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching SportsBike Details..");
        }
    }
    #endregion

    #region car classes
    public interface ICar
    {
        void GetDetails();
    }
    public class RegularCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching Regular Car Details..");
        }
    }

    public class SportsCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("Fetching Sports Car Details..");
        }
    }
    #endregion


    // Main class
    public class AbstractFactoryClassExplore
    {
        public void MainClassToCall()
        {
            // Now how do we fetch method of each class??? As below
            // Creating RegularVehicleFactory instance

            IVehicleFactory regularVehicleFactory = new RegularVehicleFactory(); // injecting class of that Interface

            IBike regularBike = regularVehicleFactory.CreateBike();
            regularBike.GetDetails();
            ICar regularCar = regularVehicleFactory.CreateCar();
            regularCar.GetDetails();

            IVehicleFactory sportsVehicleFactory = new SportsVehicleFactory();
            //sportsVehicleFactory.CreateBike() will create and return Sports Bike
            IBike sportsBike = sportsVehicleFactory.CreateBike();
            sportsBike.GetDetails();
            //sportsVehicleFactory.CreateCar() will create and return Sports Car
            ICar sportsCar = sportsVehicleFactory.CreateCar();
            sportsCar.GetDetails();
            Console.ReadKey();

        }
    }
}
