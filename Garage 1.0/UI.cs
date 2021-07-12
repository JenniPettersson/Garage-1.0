using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class UI
    {
        internal static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO THE MAIN MENU");
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n[ 1 ] If you would like to start with an empty garage"
                    + "\n[ 2 ] If you would like to start with a garage with one parked vehicle of each available kind"
                    + "\n[ 0 ] Exit the application");
                Console.Write("\r\nSelect an option: ");

                char optMain = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    optMain = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (optMain)
                {
                    case '1':
                        EmptyGarage();
                        break;
                    case '2':
                        PopulatedGarage();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2)");
                        break;
                }
            }
        }

        private static void EmptyGarage()
        {
            CapacityOfGarage();
            GarageHandler.CreateGarage();
            SubMenu();
        }

        internal static int CapacityOfGarage()
        {
            int Capacity;
            Console.WriteLine("How many parking slots will your garage contain? (At least 1 slot and maximum 99 slots.)");

            try
            {
                string input = Console.ReadLine();
                bool isTrue = int.TryParse(input, out Capacity);

                if (isTrue && Capacity < 0)
                {
                    Console.WriteLine("Garage must be between 1 and 99 slots. Setting Capacity to 1");
                    return Capacity = 1;
                }

                else if (isTrue && Capacity > 100)
                {
                    Console.WriteLine("Garage must be between 1 and 99 slots. Setting Capacity to 99");
                    return Capacity = 99;
                }

                else if (isTrue && (Capacity > 0 || Capacity < 100))
                {
                    Console.WriteLine("Capacity is " + Capacity);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.WriteLine($"Garage was created with {Capacity} parking slots.");
                    return Capacity;
                }

                return Capacity;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return Capacity = 0;
            }
        }

        private static void PopulatedGarage()
        {
            Console.WriteLine("Here is your populated garage\n\n");
            Console.WriteLine();
            SubMenu();
        }

        internal static void SubMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO THE SUB MENU");
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n[ 1 ] Add vehicle to garage"
                    + "\n[ 2 ] Remove vehicle from garage"
                    + "\n[ 3 ] List vehicles in garage"
                    + "\n[ 4 ] Search for vehicle by registration number plate"
                    + "\n[ 5 ] Search using vehicle properties"
                    + "\n[ 0 ] Exit the application");
                Console.Write("\r\nSelect an option: ");

                char optSub = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    optSub = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (optSub)
                {
                    case '1':
                        UserInputToCreateVehicle();
                        break;
                    case '2':
                        UserInputToRemoveVehicle();
                        break;
                    case '3':
                        PrintProps();
                        break;
                    case '4':
                        SearchRegNo();
                        break;
                    case '5':
                        SearchVehicleProperties();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }

            //if (!Exists(regNo.ToUpper())) 
            //        IVehicle = new Car (regNo, make, color, numberOfWheels);
            //        string result = Garage.Park(newVehicle as Vehicle) ? $"Vehicle {newVehicle} was parked in the garage";
        }

        private static void PrintProps()
        {
            Console.WriteLine("The garage contains:\n");
            Print();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void SearchRegNo()
        {
            Console.WriteLine("Enter registration number would you like to search for (Example: ABC123):");
            string searchRegNo = Console.ReadLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void UserInputToRemoveVehicle()
        {
            Console.WriteLine("Enter registration number of the vehicle you'd like to remove (Example: ABC123):");
            string removeRegNo = Console.ReadLine(); 
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void UserInputToCreateVehicle()
        {
            Console.WriteLine("What type of vehicle would you like to create (Car, Bus, Motorcyle, Airplane, Boat)?");
            string userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "car":
                    NewCar();
                    break;
                case "bus":
                    NewBus();
                    break;
                case "motorcycle":
                    NewMotorcycle();
                    break;
                case "airplane":
                    NewAirplane();
                    break;
                case "boat":
                    NewBoat();
                    break;
                default:
                    Console.WriteLine("Please enter only Car, Bus, Motorcycle, Airplane or Boat");
                    break;
            }
            return;
        }

        //private static (string, string, string) CreateVehicle()
        //{
        //    Console.WriteLine("Please enter registration number (example ABC123):");
        //    string regNo = Console.ReadLine();
        //    Console.WriteLine("Please enter color:");
        //    string color = Console.ReadLine();
        //    Console.WriteLine("Please enter make (for example Volvo or Saab or other make):");
        //    string make = Console.ReadLine();
        //    return (regNo, color, make);
        //}

        private static object NewCar()
        {
            Console.WriteLine("Please enter registration number (example ABC123):");
            string regNo = Console.ReadLine();
            Console.WriteLine("Please enter color:");
            string color = Console.ReadLine();
            Console.WriteLine("Please enter make (for example Volvo or Saab or other make):");
            string make = Console.ReadLine();
            Console.WriteLine("Please enter fuel type (for example Gas or Diesel or Electricity or other fuel type):");
            string fuelType = Console.ReadLine();
            IVehicle newVehicle = new Car(regNo, make, color, fuelType);
            //string result = Garage.vehicles.Park(newVehicle as Vehicle) ? $"Vehicle {newVehicle} was parked in the garage" :;
            return newVehicle;
        }
        private static object NewBus()
        {
            Console.WriteLine("Please enter registration number (example ABC123):");
            string regNo = Console.ReadLine();
            Console.WriteLine("Please enter color:");
            string color = Console.ReadLine();
            Console.WriteLine("Please enter make (for example Volvo or Saab or other make):");
            string make = Console.ReadLine();
            Console.WriteLine("Please enter number of seats:");
            string input = Console.ReadLine();
            bool isTrue = int.TryParse(input, out int numberOfSeats);
            IVehicle newVehicle = new Bus(regNo, make, color, numberOfSeats);
            return newVehicle;
        }

        private static object NewMotorcycle()
        {
            Console.WriteLine("Please enter registration number (example ABC123):");
            string regNo = Console.ReadLine();
            Console.WriteLine("Please enter color:");
            string color = Console.ReadLine();
            Console.WriteLine("Please enter make (for example Volvo or Saab or other make):");
            string make = Console.ReadLine();
            Console.WriteLine("Please enter cylinder volume:");
            string input = Console.ReadLine();
            bool isTrue = int.TryParse(input, out int cylinderVolume);
            IVehicle newVehicle = new Motorcycle(regNo, make, color, cylinderVolume);
            return newVehicle;
        }

        private static object NewAirplane()
        {
            Console.WriteLine("Please enter registration number (example ABC123):");
            string regNo = Console.ReadLine();
            Console.WriteLine("Please enter color:");
            string color = Console.ReadLine();
            Console.WriteLine("Please enter make (for example Volvo or Saab or other make):");
            string make = Console.ReadLine();
            Console.WriteLine("Please enter number of engines:");
            string input = Console.ReadLine();
            bool isTrue = int.TryParse(input, out int numberOfEngines);
            IVehicle newVehicle = new Airplane(regNo, make, color, numberOfEngines);
            return newVehicle;
        }

        private static object NewBoat()
        {
            Console.WriteLine("Please enter registration number (example ABC123):");
            string regNo = Console.ReadLine();
            Console.WriteLine("Please enter color:");
            string color = Console.ReadLine();
            Console.WriteLine("Please enter make (for example Volvo or Saab or other make):");
            string make = Console.ReadLine();
            Console.WriteLine("Please enter lenght:");
            string input = Console.ReadLine();
            bool isTrue = double.TryParse(input, out double lenght);
            IVehicle newVehicle = new Boat(regNo, make, color, lenght);
            return newVehicle;
        }

        private static void SearchVehicleProperties()
        {
            Console.WriteLine("Here is your search");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
