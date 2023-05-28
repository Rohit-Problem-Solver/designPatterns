using DesignPatterns.Builder.Concrete_Builder;
using DesignPatterns.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder.Director
{
    public class ConfigurationBuilder
    {

        public void BuildSystem(ISystemBuilder systembuilder
            , DbValues collection)
        {
            systembuilder.AddDrive(collection.Drive);
            systembuilder.AddMemory(collection.RAM);
            systembuilder.AddMouse(collection.Mouse);
            systembuilder.AddKeyBoard(collection.Keyboard);
            systembuilder.AddTouchScreen(collection.TouchScreen);
        }
    }

    public class DbValues
    {
        public string Drive { get; set; }
        public string RAM { get; set; }
        public string Mouse { get; set; }
        public string Keyboard { get; set; }
        public string TouchScreen { get; set; }
    }


    public class MainClassBuilder
    {
        public void MainMethod()
        {
            var dbValues = new DbValues
            {
                Drive = "TestDrive",
                Keyboard = "Dell",
                Mouse = "HP",
                RAM = "128GB",
                TouchScreen = "Yes"
            };

            #region Laptop Builder
            //Concrete Builder
            ISystemBuilder systemBuilder = new LaptopBuilder();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, dbValues);
            ComputerSystem system = systemBuilder.GetSystem();

            #endregion builder

            #region Desktop Builder
            //Step 2 Concrete Builder
            ISystemBuilder systemDesktopBuilder = new DesktopBuilder();
            //Step 3 Director
            ConfigurationBuilder builderDesktop = new ConfigurationBuilder();
            builderDesktop.BuildSystem(systemDesktopBuilder, dbValues);
            //Step 4 return the system
            ComputerSystem systemDesktop = systemDesktopBuilder.GetSystem();

            #endregion

        }
    }
}
