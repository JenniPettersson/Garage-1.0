using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Garage_1._0
{
    public class GarageHandler
    {
        private Garage<IVehicle> garage;

        public GarageHandler(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
        }
        
        public void PrintVehicles()
        {
            garage.Print();
        }

        public bool AddVehicle(IVehicle newVehicle)
        {
            if (garage.Park(newVehicle))
            {
                return true;
            }
            return false;
        }

        public bool RemoveVehicle(string regNo)
        {
            if (garage.Unpark(regNo))
            {
                return true;
            }
            return false;
        }

        //void TaBort()
        //{
        //    var _regNr = "";
        //    var _color = "";
        //    var _make = "";
        //    var _fuelType = "";
        //    int _numberOfSeats = 0;
        //    int _lenght = 0;
        //    int _numberOfEngines = 0;
        //    int _cylinderVolume = 0;
        //    Search(regNo: _regNr, color: _color, make: _make, fuelType: _fuelType, numberOfSeats: _numberOfSeats, lenght: _lenght, numberOfEngines: _numberOfEngines, cylinderVolume: _cylinderVolume);
        //}

        public void Search(string regNo = "", string color = "", string make = "", string fuelType = "", int numberOfSeats = 0, double lenght = 0, int numberOfEngines = 0, int cylinderVolume = 0)
        {

            var searchResult = garage.Select(v => v);

            if (regNo != "")
            {
                searchResult = searchResult.Where(v => v.RegNo == regNo);
            }
            if (color != "")
            {
                searchResult = searchResult.Where(v => v.Color == color);
            }
            if (make != "")
            {
                searchResult = searchResult.Where(v => v.Make == make);
            }
            if (fuelType != "")
            {
                searchResult = searchResult.Where(v => v.FuelType == fuelType);
            }
            if (numberOfSeats != 0)
            {
                searchResult = searchResult.Where(v => v.NumberOfSeats == numberOfSeats);
            }

            if (lenght != 0)
            {
                searchResult = searchResult.Where(v => v.Lenght == lenght);
            }

            if (numberOfEngines != 0)
            {
                searchResult = searchResult.Where(v => v.NumberOfEngines == numberOfEngines);
            }

            if (cylinderVolume != 0)
            {
                searchResult = searchResult.Where(v => v.CylinderVolume == cylinderVolume);
            }


            foreach (var vehicle in searchResult)
            {
                Console.WriteLine($"{vehicle.Props()}");
            }

        }
    }
}

