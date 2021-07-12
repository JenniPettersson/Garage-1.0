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
    }
}

