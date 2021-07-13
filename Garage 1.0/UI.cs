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

        //public UI()
        //{
        //   var garagehandler = new GarageHandler(capacity);
        //}

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
            Console.WriteLine($"Garage was created with {capacity} parking slots.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
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
            garagehandler = new GarageHandler(15);

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
            Console.WriteLine($"Garage was created with 15 parking slots and 5 vehicles");
            garagehandler.PrintVehicles();
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            
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
                    + "\n[ 6 ] Main menu (you lose your current garage if you have started to build and populate one)"
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
                    case '6':
                        MainMenu();
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

        public void SearchRegNo()
        {
            Console.WriteLine("Enter registration number would you like to search for (Example: abc123):");
            string input = Console.ReadLine();
            string regNo = input.ToLower();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            garagehandler.Search(regNo);
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Enter registration number of the vehicle you'd like to remove (Example: abc123):");
            string input = Console.ReadLine();
            string removeRegNo = input.ToLower();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            bool result = garagehandler.RemoveVehicle(removeRegNo);

            if (result == true)
            {
                Console.WriteLine($"Vehicle with registration number {removeRegNo} was removed from the garage");
            }
            else
            {
                Console.WriteLine($"Vehicle with registration number {removeRegNo} was not removed from the garage, try again");
            }

            Console.WriteLine(result);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
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
            IVehicle newVehicle = new Car(regNo, color, make, fuelType);
            bool result = garagehandler.AddVehicle(newVehicle as Vehicle);

            if (result == true)
                {
                Console.WriteLine($"Vehicle {newVehicle} was parked in the garage");
            }
            else {
                Console.WriteLine($"Vehicle {newVehicle} was not parked, try again");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
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
            IVehicle newVehicle = new Bus(regNo, color, make, numberOfSeats);
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

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
            IVehicle newVehicle = new Motorcycle(regNo, color, make, cylinderVolume);
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

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
            IVehicle newVehicle = new Airplane(regNo, color, make, numberOfEngines);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            
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
            IVehicle newVehicle = new Boat(regNo, color, make, lenght);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            return newVehicle;
        }

        public void SearchVehicleProperties()
        {
            string regNo = "";
            string color = "";
            string make = "";
            string fuelType = "";
            int numberOfSeats = 0;
            double lenght = 0;
            int numberOfEngines = 0;
            int cylinderVolume = 0;

            //string[] searchChoices = new string[] { "regNo", "color", "make", "fuelType", "numberOfSeats", "lenght", "numberOfEngines", "cylinderVolume" };
            Console.WriteLine("Would you like to search for registration number? (Y/N)");
            string userRegNo = Console.ReadLine();
            if ((userRegNo == "Y" || userRegNo == "y" || userRegNo == "Yes" || userRegNo == "yes") && userRegNo != null)
            {
                Console.WriteLine("Please enter registration number (Example: ABC123):");
                string unalteredRegNo = Console.ReadLine();
                regNo = unalteredRegNo.ToLower();
            }
            else if ((userRegNo == "N" || userRegNo == "n" || userRegNo == "No" || userRegNo == "no") && userRegNo != null)
            {
                Console.WriteLine("Ok, no search for registration number");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            //foreach (var s in searchChoices)
            //{
            //    Console.WriteLine($"Would you like to search for {s}? (Y/N)");
            //    string input = Console.ReadLine();
            //    if ((input == "Y" || input == "y" || input == "Yes" || input == "yes") && input != null)
            //    {
            //        Console.WriteLine($"Please enter {s}:");
            //        string this.s = Console.ReadLine();
            //    }
            //    else ((input == "N" || input == "n" || input == "No" || input == "no") && input != null)
            //    {
            //        Console.WriteLine($"Ok, no search for {s}");
            //    }
            //}

            Console.WriteLine("Would you like to search for color? (Y/N)");
            string userChoiceColor = Console.ReadLine();
            if ((userChoiceColor == "Y" || userChoiceColor == "y" || userChoiceColor == "Yes" || userChoiceColor == "yes") && userChoiceColor != null)
            {
                Console.WriteLine("Please enter color (Example: Yellow):");
                color = Console.ReadLine();
            }
            else if ((userChoiceColor == "N" || userChoiceColor == "n" || userChoiceColor == "No" || userChoiceColor == "no") && userChoiceColor != null)
            {
                Console.WriteLine("Ok, no search for color");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            Console.WriteLine("Would you like to search for make? (Y/N)");
            string userChoiceMake = Console.ReadLine();
            if ((userChoiceMake == "Y" || userChoiceMake == "y" || userChoiceMake == "Yes" || userChoiceMake == "yes") && userChoiceMake != null)
            {
                Console.WriteLine("Please enter make (Example: Volvo):");
                make = Console.ReadLine();
            }
            else if ((userChoiceMake == "N" || userChoiceMake == "n" || userChoiceMake == "No" || userChoiceMake == "no") && userChoiceMake != null)
            {
                Console.WriteLine("Ok, no search for make");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            Console.WriteLine("Would you like to search for fuel type? (Y/N)");
            string userChoiceFuelType = Console.ReadLine();
            if ((userChoiceMake == "Y" || userChoiceMake == "y" || userChoiceMake == "Yes" || userChoiceMake == "yes") && userChoiceMake != null)
            {
                Console.WriteLine("Please enter Fuel Type (Example: Gas):");
                fuelType = Console.ReadLine();
            }
            else if ((userChoiceFuelType == "N" || userChoiceFuelType == "n" || userChoiceFuelType == "No" || userChoiceFuelType == "no") && userChoiceFuelType != null)
            {
                Console.WriteLine("Ok, no search for fuel type");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            Console.WriteLine("Would you like to search for number of seats? (Y/N)");
            string userChoiceNumberOfSeats = Console.ReadLine();
            if ((userChoiceNumberOfSeats == "Y" || userChoiceNumberOfSeats == "y" || userChoiceNumberOfSeats == "Yes" || userChoiceNumberOfSeats == "yes") && userChoiceNumberOfSeats != null)
            {
                Console.WriteLine("Please enter number of seats (Example: 4):");
                string input = Console.ReadLine();
                bool isTrue = int.TryParse(input, out numberOfSeats);
            }
            else if ((userChoiceNumberOfSeats == "N" || userChoiceNumberOfSeats == "n" || userChoiceNumberOfSeats == "No" || userChoiceNumberOfSeats == "no") && userChoiceNumberOfSeats != null)
            {
                Console.WriteLine("Ok, no search for number of seats");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            Console.WriteLine("Would you like to search for lenght? (Y/N)");
            string userChoiceLenght = Console.ReadLine();
            if ((userChoiceLenght == "Y" || userChoiceLenght == "y" || userChoiceLenght == "Yes" || userChoiceLenght == "yes") && userChoiceLenght != null)
            {
                Console.WriteLine("Please enter lenght (Example: 5):");
                string input = Console.ReadLine();
                bool isTrue = double.TryParse(input, out lenght);
            }
            else if ((userChoiceLenght == "N" || userChoiceLenght == "n" || userChoiceLenght == "No" || userChoiceLenght == "no") && userChoiceLenght != null)
            {
                Console.WriteLine("Ok, no search for lenght");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            Console.WriteLine("Would you like to search for number of engines? (Y/N)");
            string userChoiceNumberOfEngines = Console.ReadLine();
            if ((userChoiceNumberOfEngines == "Y" || userChoiceNumberOfEngines == "y" || userChoiceNumberOfEngines == "Yes" || userChoiceNumberOfEngines == "yes") && userChoiceNumberOfEngines != null)
            {
                Console.WriteLine("Please enter number of engines (Example: 2):");
                string input = Console.ReadLine();
                bool isTrue = int.TryParse(input, out numberOfEngines);
            }
            else if ((userChoiceNumberOfEngines == "N" || userChoiceNumberOfEngines == "n" || userChoiceNumberOfEngines == "No" || userChoiceNumberOfEngines == "no") && userChoiceNumberOfEngines != null)
            {
                Console.WriteLine("Ok, no search for number of engines");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            Console.WriteLine("Would you like to search cylinder volume? (Y/N)");
            string userChoiceCylinderVolume = Console.ReadLine();
            if ((userChoiceCylinderVolume == "Y" || userChoiceCylinderVolume == "y" || userChoiceCylinderVolume == "Yes" || userChoiceCylinderVolume == "yes") && userChoiceCylinderVolume != null)
            {
                Console.WriteLine("Please enter cylinder volume (Example: 14):");
                string input = Console.ReadLine();
                bool isTrue = int.TryParse(input, out cylinderVolume);
            }
            else if ((userChoiceCylinderVolume == "N" || userChoiceCylinderVolume == "n" || userChoiceCylinderVolume == "No" || userChoiceCylinderVolume == "no") && userChoiceCylinderVolume != null)
            {
                Console.WriteLine("Ok, no search for cylinder volume");
            }

            else
            {
                Console.WriteLine("No allowed choice detected, continuing");
            }

            garagehandler.Search(regNo, color, make, fuelType, numberOfSeats, lenght, numberOfEngines, cylinderVolume);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}




//if (!Exists(regNo.ToUpper())) 
//        IVehicle = new Car (regNo, make, color, numberOfWheels);
//        string result = Garage.Park(newVehicle as Vehicle) ? $"Vehicle {newVehicle} was parked in the garage";