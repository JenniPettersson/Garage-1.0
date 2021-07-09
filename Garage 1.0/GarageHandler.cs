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
        internal static int CapacityofGarage()
        {
            int Capacity = 0;
            Console.WriteLine("How many parking slots will your garage contain? (At least 1 slot and maximum 99 slots.)");

            try
            {
                string input = Console.ReadLine();
                bool isTrue = int.TryParse(input, out Capacity);

                if (isTrue && (Capacity < 1 || Capacity > 100))
                {
                    Console.WriteLine("Garage must be between 1 and 99 slots.");
                    return Capacity = 0;
                }

                else if (isTrue && (Capacity > 1 || Capacity < 100))
                {
                    Console.WriteLine("Capacity is " + Capacity);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    return Capacity;
                }

                return Capacity;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return Capacity;
            }
        }

        internal static Object CreateGarage(int capacity)
        {
            int Capacity = capacity;
            Object[] Garage = new Object[Capacity];
            Console.WriteLine($"Garage was created with {Capacity} parking slots.");
            return Garage;
        }

        internal static void AddVehicles()
        {
            Console.WriteLine("What type of vehicle would you like to park (Car, Bus, Motorcyle, Airplane, Boat)?");
            string Vehicle = Console.ReadLine();
            Console.WriteLine("Please enter registration number for vehicle");
            string RegNo = Console.ReadLine();



            //if (!Exists(regNo.ToUpper()))
            //        IVehicle = new Car regNo, make, color, numberOfWheels);
            //        string result = Garage.Park(newVehicle as Vehicle) ? $"Vehicle {newVehicle} was parked in the garage";
        }

    }
}
