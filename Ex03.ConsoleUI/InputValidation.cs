using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal static class InputValidation
    {
        internal static int GetTypeOfVehicle(Ex03.GarageLogic.Garage i_Garage)
        {
            Console.WriteLine(
@"Please select the type of vehicle you wish to register into the garage:
0. None of the above (Exit).
{0}",
i_Garage.GetVehiclesTypes());
            int typeOfVehicle = GetIntValueInRange(0, i_Garage.GetNumberOfAcceptedVehicle());
            return typeOfVehicle;
        }

        internal static string GetCarLicense()
        {
            string carLicense = Console.ReadLine();
            try
            {
                Ex03.GarageLogic.Validation.NumberValidation(carLicense);
            }
            catch (FormatException)
            {
                Console.WriteLine(" Invalid number format. Please enter numbers only without any spaces.");
                carLicense = GetCarLicense();
            }

            return carLicense;
        }

        internal static string GetPhoneNumber()
        {
            string phoneNumber = Console.ReadLine();
            try
            {
                Ex03.GarageLogic.Validation.NumberValidation(phoneNumber);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format. Please enter numbers only without any spaces.");
                phoneNumber = GetPhoneNumber();
            }

            return phoneNumber;
        }

        internal static string GetName()
        {
            string name = Console.ReadLine();
            try
            {
                Ex03.GarageLogic.Validation.NameValidation(name);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Name format. Please enter a valid name format");
                name = GetName();
            }

            return name;
        }

        internal static float GetFloatValueInRange(float i_MinIndex, float i_MaxIndex)
        {
            float returnValue = -1;
            string input = Console.ReadLine();
            try
            {
                returnValue = Ex03.GarageLogic.Validation.FloatValueInRange(i_MinIndex, i_MaxIndex, input);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.Please try again with a valid value");
                returnValue = GetFloatValueInRange(i_MinIndex, i_MaxIndex);
            }

            return returnValue;
        }

        internal static int GetIntValueInRange(int i_MinIndex, int i_MaxIndex)
        {
            int returnValue = -1;

            string input = Console.ReadLine();
            try
            {
                returnValue = Ex03.GarageLogic.Validation.IntValueInRange(i_MinIndex, i_MaxIndex, input);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.Please try again with a valid value");
                returnValue = GetIntValueInRange(i_MinIndex, i_MaxIndex);
            }

            return returnValue;
        }

        internal static float GetCurAirPressure(int i_TypeOfCar, Ex03.GarageLogic.Garage i_Garage)
        {
            float maxAirPressure = 0;
            switch (i_TypeOfCar)
            {
                case 1:
                case 2:
                    maxAirPressure = i_Garage.CarMaxAirPressure();
                    break;
                case 3:
                case 4:
                    maxAirPressure = i_Garage.BikeMaxAirPressure();
                    break;
                case 5:
                    maxAirPressure = i_Garage.TruckMaxAirPressure();
                    break;
            }

            return GetFloatValueInRange(0, maxAirPressure);
        }
    }
}
