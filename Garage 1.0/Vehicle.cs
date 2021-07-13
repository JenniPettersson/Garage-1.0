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
        public string FuelType { get; set; }
        public int NumberOfSeats { get; set; }
        public double Lenght { get; set; }
        public int NumberOfEngines { get; set; }
        public int CylinderVolume { get; set; }

        public Vehicle(string regno, string color, string make)
        {
            RegNo = regno;
            Color = color;
            Make = make;
        }
        public virtual string Props()
        {
            return $"Reg No: {RegNo}, Color: {Color}, Make: {Make}";
        }

        //public string PropsFull()
        //{
        //    return $"Reg No: {RegNo}, Color: {Color}, Make: {Make}, Fuel type: {FuelType}, Seats: {NumberOfSeats}, Lenght: {Lenght}, Engines: {NumberOfEngines}, Cylinder volume: {CylinderVolume};
        //}
    }
        public interface IVehicle
    {
        public string RegNo { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string FuelType { get; set; }
        public int NumberOfSeats { get; set; }
        public double Lenght { get; set; }
        public int NumberOfEngines { get; set; }
        public int CylinderVolume { get; set; }

        public int Props();
    }

    class Car : Vehicle
    {
    public string FuelType { get; set; }

    public Car(string regno, string color, string make, string fueltype) : base(regno, color, make)
        {
            FuelType = fueltype;
        }
        public override string Props()
        {
            return $"{base.Props()}, Fuel type: {FuelType}";
        }
    }

    class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string regno, string color, string make, int numberofseats) : base(regno, color, make)
        {
            NumberOfSeats = numberofseats;
        }

        public override string Props()
        {
            return $"{base.Props()}, Seats: {NumberOfSeats}";
        }
    }

    class Boat : Vehicle
    {
        public double Lenght { get; set; }
        public Boat(string regno, string color, string make, double lenght) : base(regno, color, make)
        {
            Lenght = lenght;
        }

        public override string Props()
        {
            return $"{base.Props()}, Lenght: {Lenght}";
        }
    }

    class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(string regno, string color, string make, int numberofengines) : base(regno, color, make)
        {
            NumberOfEngines = numberofengines;
        }

        public override string Props()
        {
            return $"{base.Props()}, Engines: {NumberOfEngines}";
        }
    }

    class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(string regno, string color, string make, int cylindervolume) : base(regno, color, make)
        {
            CylinderVolume = cylindervolume;
        }

        public override string Props()
        {
            return $"{base.Props()}, Cylinder volume: {CylinderVolume}";
        }
    }
}
