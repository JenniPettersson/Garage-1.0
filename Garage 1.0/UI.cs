using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class UI
    {
        public GarageHandler garagehandler;

        public UI()
        {
            //var garagehandler = new GarageHandler(capacity);
        }

        //garagehandler = new GarageHandler(capacity);
        public void MainMenu()
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

        public void EmptyGarage()
        {
            CreateGarage(CapacityOfGarage());
            SubMenu();
        }

        public void CreateGarage(int capacity)
        {
            garagehandler = new GarageHandler(capacity);
            //var garage = new Garage<IVehicle>();
            //garagehandler.CreateGarage(capacity);
            Console.WriteLine($"Garage was created with {capacity} parking slots.");
        }

        public int CapacityOfGarage()
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

        public void PopulatedGarage()
        {
            var garagehandler = new GarageHandler(15);
            //var garage = new Garage<IVehicle>();
            //garagehandler.CreateGarage(15);

            IVehicle newVehicle1 = new Car("jen345", "Volvo", "red", "Diesel");
            garagehandler.AddVehicle(newVehicle1);
            IVehicle newVehicle2 = new Bus("bro754", "Scania", "Grey", 80);
            garagehandler.AddVehicle(newVehicle2);
            IVehicle newVehicle3 = new Motorcycle("far386", "Ducati", "Black", 1400);
            garagehandler.AddVehicle(newVehicle3);
            IVehicle newVehicle4 = new Boat("cos462", "Nimbus", "White", 18);
            garagehandler.AddVehicle(newVehicle4);
            IVehicle newVehicle5 = new Airplane("sas462", "Boeing", "White", 4);
            garagehandler.AddVehicle(newVehicle5);
            garagehandler.PrintVehicles();
            SubMenu();
        }

        public void SubMenu()
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
                        CreateVehicle();
                        break;
                    case '2':
                        RemoveVehicle();
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
        }

        public void PrintProps()
        {
            Console.WriteLine("The garage contains:\n");
            garagehandler.PrintVehicles();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public string SearchRegNo()
        {
            Console.WriteLine("Enter registration number would you like to search for (Example: abc123):");
            string input = Console.ReadLine();
            string searchRegNo = input.ToLower();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return searchRegNo;
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Enter registration number of the vehicle you'd like to remove (Example: abc123):");
            string input = Console.ReadLine();
            string removeRegNo = input.ToLower();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            bool result = garagehandler.RemoveVehicle(removeRegNo);

            //$"The vehicle with registration number {removeRegNo} was removed from the garage" : $"The vehicle with registration number{removeRegNo} was not removed, try again"
            Console.WriteLine(result);
        }

        public void CreateVehicle()
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

        public void NewCar()
        {
            Console.WriteLine("Please enter registration number (example abc123):");
            string userRegNo = Console.ReadLine();
            string regNo = userRegNo.ToLower();
            Console.WriteLine("Please enter color:");
            string color = Console.ReadLine();
            Console.WriteLine("Please enter make (for example Volvo or Saab or other make):");
            string make = Console.ReadLine();
            Console.WriteLine("Please enter fuel type (for example Gas or Diesel or Electricity or other fuel type):");
            string fuelType = Console.ReadLine();
            IVehicle newVehicle = new Car(regNo, make, color, fuelType);
            bool result = garagehandler.AddVehicle(newVehicle as Vehicle);

            if (result == true)
                {
                Console.WriteLine($"Vehicle {newVehicle} was parked in the garage");
            }
            else {
                Console.WriteLine($"Vehicle {newVehicle} was not parked, try again");
            } 
        }

        public object NewBus()
        {
            Console.WriteLine("Please enter registration number (example abc123):");
            string userRegNo = Console.ReadLine();
            string regNo = userRegNo.ToLower();
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

        public object NewMotorcycle()
        {
            Console.WriteLine("Please enter registration number (example abc123):");
            string userRegNo = Console.ReadLine();
            string regNo = userRegNo.ToLower();
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

        public object NewAirplane()
        {
            Console.WriteLine("Please enter registration number (example abc123):");
            string userRegNo = Console.ReadLine();
            string regNo = userRegNo.ToLower();
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

        public object NewBoat()
        {
            Console.WriteLine("Please enter registration number (example abc123):");
            string userRegNo = Console.ReadLine();
            string regNo = userRegNo.ToLower();
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

        public void SearchVehicleProperties()
        {
            Console.WriteLine("Here is your search");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }

    //if (!Exists(regNo.ToUpper())) 
    //        IVehicle = new Car (regNo, make, color, numberOfWheels);
    //        string result = Garage.Park(newVehicle as Vehicle) ? $"Vehicle {newVehicle} was parked in the garage";
}
