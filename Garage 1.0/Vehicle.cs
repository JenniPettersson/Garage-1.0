using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Vehicle
    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        public Vehicle(string regno, string color, int numberofwheels)
        {
            RegNo = regno;
            Color = color;
            NumberOfWheels = numberofwheels;
        }
    }

    class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(string regno, string color, int numberofwheels, int numberofengines) : base(regno, color, numberofwheels)
        {
            NumberOfEngines = numberofengines;
        }
    }

    class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(string regno, string color, int numberofwheels, int cylindervolume) : base(regno, color, numberofwheels)
        {
            CylinderVolume = cylindervolume;
        }
    }

    class Car : Vehicle
    {
    public string FuelType { get; set; }

    public Car(string regno, string color, int numberofwheels, string fueltype) : base(regno, color, numberofwheels)
        {
            FuelType = fueltype;
        }

    }

    class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string regno, string color, int numberofwheels, int numberofseats) : base(regno, color, numberofwheels)
        {

        }
    }

    class Boat : Vehicle
    {
        public int Lenght { get; set; }
        public Boat(string regno, string color, int numberofwheels, int lenght) : base(regno, color, numberofwheels)
        {
            Lenght = lenght;
        }
    }

}
