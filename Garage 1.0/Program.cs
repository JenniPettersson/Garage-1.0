using System;

namespace Garage_1._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

            Console.Clear();
            Console.WriteLine("WELCOME TO THE MAIN MENU");
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. If you would like to start with an empty garage"
                + "\n2. If you would like to start with a garaged with one parked vehicle of each available kind"
                + "\n0. Exit the application");
            Console.Write("\r\nSelect an option: ");

            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }

            switch (input)
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

        public static void PopulatedGarage()
        {
            Console.WriteLine("Here is your empty garage");
        }

        public static void EmptyGarage()
        {
            int Capacity = GarageHandler.CapacityofGarage();
            GarageHandler.CreateGarage(Capacity);
            GarageHandler.AddVehicles();
        }
    }
}
