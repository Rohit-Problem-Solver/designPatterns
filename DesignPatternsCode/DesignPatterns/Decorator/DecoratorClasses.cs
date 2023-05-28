using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    class DecoratorClasses
    {
        //can be altered by decorators. 
        // remember this also include pattern to use interface as return type
        public interface ICar
        {
            ICar ManufactureCar(); // Observe the return type is Interface itself, used to retun diff derived class from the base class
        }

        //concrete class, its an example of basic functionality from base class
        public class BMWCar : ICar
        {
            private string CarName = "BMW";
            public string CarBody { get; set; }
            public string CarDoor { get; set; }
            public string CarWheels { get; set; }
            public string CarGlass { get; set; }
            public string Engine { get; set; }
            public override string ToString()
            {
                return "BMWCar [CarName=" + CarName + ", CarBody=" + CarBody + ", CarDoor=" + CarDoor + ", CarWheels="
                                + CarWheels + ", CarGlass=" + CarGlass + ", Engine=" + Engine + "]";
            }

            public ICar ManufactureCar()
            {

                CarBody = "carbon fiber material";
                CarDoor = "4 car doors";
                CarWheels = "6 car glasses";
                CarGlass = "4 MRF wheels";
                return this;

                // Notice this type of return because of the interface return type that we defined above
            }
        }

        public abstract class CarDecorator : ICar
        {
            //Create a Field to store the Concrete Component
            protected ICar car;
            //Initializing the Field using Constructor
            //While Creating an instance of the CarDecorator (Instance of the Child Class that Implements CarDecorator abstract),
            //**We need to pass the existing car object which we want to decorate
            public CarDecorator(ICar car)
            {
                //Store that existing car object in the car variable
                this.car = car;
            }
            //Providing Implementation for the Base Component Interface
            //Here, we are just calling the Concrete Component ManufactureCar method
            //We are making this Method Virtual to allow the Child Concrete Decorator class to override
            public virtual ICar ManufactureCar()
            {
                //Call the Existing Car Object ManufactureCar method to return the car without engine
                //Later in the Child class of this abstract we will see how to call this method 
                //and how to add an Engine
                return car.ManufactureCar();
            }
        }


        // Now creating concrete classes with respect to this CarDecorator

        class PetrolCarDecorator : CarDecorator
        {
            //Pass the existing car object while creating the Instance of PetrolCarDecorator class
            //Also pass the same existing pizza object to the base class constructor 
            //i.e. CarDecorator abstract class constructor
            public PetrolCarDecorator(ICar car) : base(car)
            {
            }
            //Overriding the ManufactureCar method to add Petrol Engine
            public override ICar ManufactureCar()
            {
                //First Call the Concrete Components ManufactureCar Method 
                base.ManufactureCar();
                //Then Add a Petrol Engine by calling the AddEngine Method
                AddEngine(car);
                return car;
            }
            public void AddEngine(ICar car)
            {
                if (car is BMWCar BMWCar)
                {
                    BMWCar.Engine = "Petrol Engine";
                    Console.WriteLine("PetrolCarDecorator added Petrol Engine to the Car : " + car);
                }
            }
        }

        class DecoratorMainClass
        {
            public void MainMethod()
            {
                ICar bmwCar1 = new BMWCar();
                //Calling the ManufactureCar method will create the BMWCar without an engine
                bmwCar1.ManufactureCar();
                Console.WriteLine(bmwCar1 + "\n");
                //Adding Petrol Engine to the bmwCar1
                //Create an instance PetrolCarDecorator class and 
                //pass existing bmwCar1 as an argument to the Constructor which we want to decorate
                PetrolCarDecorator carWithPetrolEngine = new PetrolCarDecorator(bmwCar1);
                //Calling the ManufactureCar method on the carWithDieselEngine object will add Diesel Engine to the bmwCar1 car
                carWithPetrolEngine.ManufactureCar();
                Console.ReadKey();
            }
        }

    }
}
