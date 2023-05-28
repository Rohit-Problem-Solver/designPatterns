using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class ObserverDPClass
    {
        public void ObserverMethod()
        {
            //Create a Product with Out Of Stock Status
            Subject RedMI = new Subject("Red MI Mobile", "Out Of Stock");
            //User Anurag will be created and user1 object will be registered to the subject
            Observer user1 = new Observer("Anurag", RedMI);
            //User Pranaya will be created and user1 object will be registered to the subject
            Observer user2 = new Observer("Pranaya", RedMI);
            //User Priyanka will be created and user3 object will be registered to the subject
            Observer user3 = new Observer("Priyanka", RedMI);

            Console.WriteLine();
            // Now product is available
            RedMI.SetAvailability("Available Now");
            //Console.Read();
        }
    }

    public interface ISubject // Remember 3 methods to be made. // And the methods have Observers as Argument
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class Subject : ISubject
    {
        // Added propertis to have some values in it
        public string ProductName { get; set; }
        public string IsAvailable { get; set; }

        public Subject(string ProductName, string IsAvailable)
        {
            this.ProductName = ProductName;
            this.IsAvailable = IsAvailable;
        }

        private List<IObserver> observers = new List<IObserver>();
        public void NotifyObservers()
        {
            // We can use the list in Observer and notify them
            foreach(var obs in observers)
            {
                obs.update(IsAvailable);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        // Now think of other methods
        public void SetAvailability(string IsAvailable) // This method is used to call notify method
        {
            this.IsAvailable = IsAvailable;
            NotifyObservers();
        }
    }





    public interface IObserver
    {
        void update(string availability);
    }

    public class Observer : IObserver
    {
        public string UserName { get; set; }
        public Observer(string userName, ISubject subject)
        {
            UserName = userName;
            subject.RegisterObserver(this); // Note here we pass subject ref so we can register inside the class itself
        }

        public void update(string availabiliy)
        {
            Console.WriteLine("Hello " + UserName + ", Product is now " + availabiliy + " on Amazon");
        }
    }
}
