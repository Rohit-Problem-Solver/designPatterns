using DesignPatterns.Abstract_Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add your own Class Function in every class
            // From here we only make calls to your function

            var observerTest = new ObserverDPClass();
            observerTest.ObserverMethod();

            var abstractFactory = new AbstractFactoryClassExplore();
            abstractFactory.MainClassToCall();


            Console.ReadLine();
        }
    }

}
