using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public abstract class Vehicle : IVehicle
    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }

        public Vehicle(string regno, string color, string make)
        {
            RegNo = regno;
            Color = color;
            Make = make;
        }
    }
        public interface IVehicle
    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }

    }

    class Airplane : Vehicle, IVehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(string regno, string color, string make, int numberofengines) : base(regno, color, make)
        {
            NumberOfEngines = numberofengines;
        }
    }

    class Motorcycle : Vehicle, IVehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(string regno, string color, string make, int cylindervolume) : base(regno, color, make)
        {
            CylinderVolume = cylindervolume;
        }
    }

    class Car : Vehicle, IVehicle
    {
    public string FuelType { get; set; }

    public Car(string regno, string color, string make, string fueltype) : base(regno, color, make)
        {
            FuelType = fueltype;
        }
    }

    class Bus : Vehicle, IVehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string regno, string color, string make, int numberofseats) : base(regno, color, make)
        {
            NumberOfSeats = numberofseats;
        }
    }

    class Boat : Vehicle, IVehicle
    {
        public double Lenght { get; set; }
        public Boat(string regno, string color, string make, double lenght) : base(regno, color, make)
        {
            Lenght = lenght;
        }
    }

}
