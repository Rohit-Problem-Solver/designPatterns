using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder.IBuilder
{
    public interface ISystemBuilder
    {
        void AddMemory(string memory);
        void AddDrive(string size);

        void AddKeyBoard(string type);
        void AddMouse(string type);

        void AddTouchScreen(string enabled);
        ComputerSystem GetSystem();
    }
}
