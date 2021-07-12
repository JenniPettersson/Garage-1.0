using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Garage_1._0
{
    class GarageHandler
    {
        private Garage<IVehicle> garage;

        public GarageHandler(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
        }
        
        public Garage<IVehicle> CreateGarage(int capacity)
        {
            var garage = new Garage<IVehicle>(capacity);
            return garage;
        }

        public void PrintVehicles()
        {
            garage.Print();
        }

        public void AddVehicle(IVehicle newVehicle)
        {
            garage.Park(newVehicle);
        }

        public void RemoveVehicle(string regNo)
        {
            garage.Unpark(regNo);
        }
    }
}

