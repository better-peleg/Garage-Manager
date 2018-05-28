using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal static class GarageUI
    {
        private const string k_WelcomeMessage =
@"Welcome to Guy & Peleg 's Garage! a place where efficiency meets quality and good grades!
How can we help you?";

        private const string k_MenuMessage =
@"
*********************************************************************************
*  ________   ___    ______    _______                                          *
* (  ______) / _ \  (_____ \  ( ______)                                         *
* | |   ___ ( (_) )  _____) ) | |   ___  _____   ____  _____   ____  _____      *
* | | (_  | ) _ (  |  ____/   | | (_  |(____ | / ___)(____ | / _  || ___ |      *
* | |___) |( (/  \ | |        | |___) |/ ___ || |    / ___ |( (_| || ____|      *
*  \_____/  \__/\_)|_|         \_____/ \_____||_|    \_____| \___ ||_____)      *
*                                                           (_____|             *
*********************************************************************************
 
Please select an option from the menu:
1. Enter a new vehicle to the garage.
2. Display a list of license numbers of all the cars that are inside the garage.
3. Change a stored vehicle status
4. Inflate vehicle wheels to maximum pressure.
5. Fuel gasoline vehicle.
6. Charge electric vehicle.
7. Show full vehicle information
8. Exit Garage";

        private const string k_GoodByeMessage =
@"Thanks for visiting, Hope you enjoyed our garage.";

        internal static void Start()
        {
            Ex03.GarageLogic.Garage garage = new Ex03.GarageLogic.Garage();
            bool GarageOpen = true;
            Console.WriteLine(k_WelcomeMessage);
            int userSelection;
            while (GarageOpen)
            {
                Console.WriteLine(k_MenuMessage);
                userSelection = InputValidation.GetIntValueInRange(1, 8);
                switch (userSelection)
                {
                    case 1:
                        addNewVehicleToGarage(garage);
                        break;
                    case 2:
                        showCarsByStatus(garage);
                        break;
                    case 3:
                        changeVehicleStatus(garage);
                        break;
                    case 4:
                        inflateWheelsToMax(garage);
                        break;
                    case 5:
                        fuelVehicle(garage);
                        break;
                    case 6:
                        chargeVehicle(garage);
                        break;
                    case 7:
                        showVehicleInformation(garage);
                        break;
                    case 8:
                        GarageOpen = false;
                        break;
                }

                Console.WriteLine("Press enter to get back to the menu.");
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine(k_GoodByeMessage + Environment.NewLine + "Press enter to leave");
            Console.ReadLine();
        }

        private static void showVehicleInformation(Ex03.GarageLogic.Garage i_Garage)
        {
            Console.WriteLine(i_Garage.ToString());
        }

        private static void chargeVehicle(Ex03.GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicles license number");
            string licenseNumber = InputValidation.GetCarLicense();
            bool isCarExists = i_Garage.CarIsAlreadyInGarage(licenseNumber);
            if (!isCarExists)
            {
                Console.WriteLine("Could not locate car in the garage. Please try again later.");
            }
            else
            {
                Console.WriteLine("Please enter the amount you would like to fill (in minutes)");
                float amountToFill = InputValidation.GetFloatValueInRange(0, float.MaxValue);
                try
                {
                    i_Garage.FillEnergy(licenseNumber, 5, amountToFill / 60);
                }
                catch (ArgumentException e1)
                {
                    Console.WriteLine(e1.GetType() + ": Wrong type of Energy. Better luck next time.");
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException e2)
                {
                    Console.WriteLine(e2.GetType() + ": Invalid amount to fill. Better luck next time.");
                }
            }
        }

        private static void fuelVehicle(Ex03.GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicles license number");
            string licenseNumber = InputValidation.GetCarLicense();
            bool isCarExists = i_Garage.CarIsAlreadyInGarage(licenseNumber);
            if (!isCarExists)
            {
                Console.WriteLine("Could not locate car in the garage. Please try again later.");
            }
            else
            {
                string selectMsg = string.Format(
  @"Please select type of Fuel/Electric you would like to fill in your vehicle
{0}",
i_Garage.GetEnergyTypes());
                Console.WriteLine(selectMsg);
                int selection = InputValidation.GetIntValueInRange(1, i_Garage.GetNumberOfEnergyType());
                Console.WriteLine("Please enter the amount you would like to fill (in Litres)");
                float amountToFill = InputValidation.GetFloatValueInRange(0, float.MaxValue);
                try
                {
                    i_Garage.FillEnergy(licenseNumber, selection, amountToFill);
                }
                catch (ArgumentException e1)
                {
                    Console.WriteLine(e1.Message);
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException e2)
                {
                    Console.WriteLine(e2.Message);
                }
            }
        }

        private static void inflateWheelsToMax(Ex03.GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicles license number");
            string licenseNumber = InputValidation.GetCarLicense();
            bool isCarExists = i_Garage.CarIsAlreadyInGarage(licenseNumber);
            if (isCarExists)
            {
                i_Garage.InflateWheelsToMax(licenseNumber);
            }
            else
            {
                Console.WriteLine("Could not locate car in the garage. Please try again later.");
            }
        }

        private static void changeVehicleStatus(Ex03.GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicles license number");
            string licenseNumber = InputValidation.GetCarLicense();
            bool isCarExists = i_Garage.CarIsAlreadyInGarage(licenseNumber);
            if (isCarExists)
            {
                string msg = string.Format(
@"Please select the new vehicle status
{0}",
i_Garage.GetStatusOptions());
                Console.WriteLine(msg);
                int selection = InputValidation.GetIntValueInRange(1, i_Garage.GetNumberOfStatusOptions());
                i_Garage.ChangeCarStatus(licenseNumber, selection);
            }
            else
            {
                Console.WriteLine("Could not locate car in the garage. Please try again later.");
            }
        }

        private static void showCarsByStatus(Ex03.GarageLogic.Garage i_Garage)
        {
            string optionsMsg = string.Format(
@"Please select which cars information would you like to see.
0. All
{0}",
i_Garage.GetStatusOptions());
            Console.WriteLine(optionsMsg);
            int selection = InputValidation.GetIntValueInRange(0, i_Garage.GetNumberOfStatusOptions());
            Console.WriteLine(i_Garage.VehcilesByStatusToString(selection));
        }

        private static void addNewVehicleToGarage(Ex03.GarageLogic.Garage i_Garage)
        {
            Dictionary<string, object> vehicleDic = Ex03.GarageLogic.VehicleInGarage.GetVehicleDictionary();
            Console.WriteLine("Please enter the vehicle's owner name");
            string name = InputValidation.GetName();
            Console.WriteLine("Please enter the vehicles owner phone number");
            string phoneNumber = InputValidation.GetPhoneNumber();
            Console.WriteLine("Please enter the vehicles license number");
            vehicleDic["License number"] = InputValidation.GetCarLicense();
            if (i_Garage.CarIsAlreadyInGarage((string)vehicleDic["License number"]))
            {
                Console.WriteLine("Car is already in the garage. Please select another option from the menu.");
            }
            else
            {
                Console.WriteLine("Please enter your vehicle model name.");
                vehicleDic["Model name"] = InputValidation.GetName();
                int type = InputValidation.GetTypeOfVehicle(i_Garage);
                if (type == 0)
                {
                    return;
                }

                vehicleDic["Energy type"] = type;
                Console.WriteLine("Please enter your vehicle current Fuel/Battery level in precents (e.g if your tank/battery is half full enter 50.)");
                vehicleDic["Current energy(%)"] = InputValidation.GetFloatValueInRange(0, 100);
                Console.WriteLine("Please enter your wheels manufacturer name.");
                vehicleDic["Wheels manufacturer"] = InputValidation.GetName();
                Console.WriteLine("Please enter your current wheels air pressure.");
                vehicleDic["Current wheels pressure"] = InputValidation.GetCurAirPressure(type, i_Garage);
                Dictionary<string, object> specialProperties = Ex03.GarageLogic.AddVehicle.GetSpecialPropertiesDic(vehicleDic);
                Dictionary<string, object> copyOfSpecialDic = Ex03.GarageLogic.AddVehicle.GetSpecialPropertiesDic(vehicleDic);
                foreach (string key in copyOfSpecialDic.Keys)
                {
                    Console.WriteLine("Please choose a valid " + key + Environment.NewLine + i_Garage.GetOptions(key));
                    specialProperties[key] = Console.ReadLine();
                }

                try
                {
                    Ex03.GarageLogic.VehicleInGarage.AddNewVehicle(i_Garage, name, phoneNumber, vehicleDic, specialProperties);
                    Console.WriteLine("A new vehicle was added to the garage");
                }
                catch (ArgumentException e0)
                {
                    Console.WriteLine("Invalid input. Unable to create a new vehicle");
                }
                catch (FormatException e1)
                {
                    Console.WriteLine("Invalid input.Unable to create a new vehicle");
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException e2)
                {
                    Console.WriteLine("Invalid input.Unable to create a new vehicle");
                }
            }            
        }
    }
}