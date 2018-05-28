using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class Validation
    {
        // validation for first and last name
        public static void NameValidation(string i_Name)
        {
            if (string.IsNullOrEmpty(i_Name))
            {
                throw new FormatException("Invalid Name format.");
            }
        }

        public static bool FuelTypeValidation(Garage i_Garage, string i_VehicleLicense, int i_EnergyType)
        {
            foreach (VehicleInGarage vehicle in i_Garage.Vehicles)
            {
                if (vehicle.ID.Equals(i_VehicleLicense))
                {
                    if (vehicle.EnergyType.Equals((GarageENum.eEnergyType)i_EnergyType))
                    {
                        return true;
                    }
                }
            }

            throw new ArgumentException("Invalid Argument. Wrong energy type");
        }

        // Number validation for Car License number and Owner phone number format.
        public static void NumberValidation(string i_Number)
        {
            if (string.IsNullOrEmpty(i_Number) || i_Number.Any(char.IsWhiteSpace) || i_Number.Any(char.IsLetter))
            {
                throw new FormatException("Invalid number format. Please enter numbers only without any spaces.");
            }
        }

        public static float FloatValueInRange(float i_MinIndex, float i_MaxIndex, string i_Input)
        {
            float returnValue = -1;
            if (!(float.TryParse(i_Input, out returnValue) && returnValue >= i_MinIndex && returnValue <= i_MaxIndex))
            {
                throw new FormatException("Invalid input. Please try again with a valid value");
            }

            return returnValue;
        }

        public static int IntValueInRange(float i_MinIndex, float i_MaxIndex, string i_Input)
        {
            int returnValue = -1;
            if (!(int.TryParse(i_Input, out returnValue) && returnValue >= i_MinIndex && returnValue <= i_MaxIndex))
            {
                throw new FormatException("Invalid input. Please try again with a valid value");
            }

            return returnValue;
        }

        internal static bool GetBiohazard(string i_Input)
        {
            bool validInput = i_Input.ToUpper().Equals("YES") || i_Input.ToUpper().Equals("NO");
            if (!validInput)
            {
                throw new FormatException("Invalid Yes/No input");
            }

            return i_Input.ToUpper().Equals("YES") ? true : false;
        }
    }
}
