using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class AddVehicle
    {
        private const float k_CarMaxWheelAirPressure = 32F;
        private const float k_CarMaxBatteryLevel = 3.2f;
        private const float k_CarMaxFuelLevel = 45f;
        private const float k_TruckMaxWheelAirPressure = 28f;
        private const float k_TruckMaxFuelLevel = 115f;
        private const float k_BikeMaxWheelAirPressure = 30f;
        private const float k_BikeMaxBatteryLevel = 1.8f;
        private const float k_BikeMaxFuelLevel = 6f;      

        public static float CarMaxWheelAirPressure => k_CarMaxWheelAirPressure;

        public static float TruckMaxWheelAirPressure => k_TruckMaxWheelAirPressure;

        public static float BikeMaxWheelAirPressure => k_BikeMaxWheelAirPressure;

        public static Dictionary<string, object> GetSpecialPropertiesDic(Dictionary<string, object> i_VehicleDetails)
        {
            GarageENum.eAcceptedVehicleTypes type = (GarageENum.eAcceptedVehicleTypes)i_VehicleDetails["Energy type"];
            Dictionary<string, object> output = new Dictionary<string, object>();
            switch (type)
            {
                case GarageENum.eAcceptedVehicleTypes.FuelCar:
                case GarageENum.eAcceptedVehicleTypes.ElectricCar:
                    output = Car.CarSpecialPropertiesDictionary();
                    break;
                case GarageENum.eAcceptedVehicleTypes.FuelBike:
                case GarageENum.eAcceptedVehicleTypes.ElectricBike:
                    output = Bike.BikeSpecialPropertiesDictionary();
                    break;
                case GarageENum.eAcceptedVehicleTypes.FuelTruck:
                    output = Truck.TruckSpecialPropertiesDictionary();
                    break;
            }

            return output;      
        }

        internal static void AddTruck(Garage i_Garage, string i_OwnerName, string i_PhoneNumber, Dictionary<string, object> i_VehicleDetails, Dictionary<string, object> i_SpecialDict)
        {
            i_VehicleDetails["Max wheels pressure"] = k_TruckMaxWheelAirPressure;
            i_VehicleDetails["Max energy"] = k_TruckMaxFuelLevel;
            i_VehicleDetails["Energy type"] = GarageENum.eEnergyType.Octan96;
            Truck newTruck = new Truck(i_VehicleDetails, i_SpecialDict);
            i_Garage.AddVehicle(new VehicleInGarage(newTruck, i_OwnerName, i_PhoneNumber, (GarageENum.eEnergyType)i_VehicleDetails["Energy type"]));
        }

        internal static void AddCar(Garage i_Garage, string i_OwnerName, string i_PhoneNumber, Dictionary<string, object> i_VehicleDetails, Dictionary<string, object> i_SpecialDict)
        {
            GarageENum.eAcceptedVehicleTypes type = (GarageENum.eAcceptedVehicleTypes)i_VehicleDetails["Energy type"];
            i_VehicleDetails["Max wheels pressure"] = k_CarMaxWheelAirPressure;
            Car newCar = null;
            switch (type)
            {
                case GarageENum.eAcceptedVehicleTypes.FuelCar:
                    i_VehicleDetails["Max energy"] = k_CarMaxFuelLevel;
                    i_VehicleDetails["Energy type"] = GarageENum.eEnergyType.Octan98;
                    newCar = new Car(i_VehicleDetails, i_SpecialDict);
                    break;
                case GarageENum.eAcceptedVehicleTypes.ElectricCar:
                    i_VehicleDetails["Max energy"] = k_CarMaxBatteryLevel;
                    i_VehicleDetails["Energy type"] = GarageENum.eEnergyType.Electric;
                    newCar = new Car(i_VehicleDetails, i_SpecialDict);
                    break;
            }

            i_Garage.AddVehicle(new VehicleInGarage(newCar, i_OwnerName, i_PhoneNumber, (GarageENum.eEnergyType)i_VehicleDetails["Energy type"]));
        }

        internal static void AddBike(Garage i_Garage, string i_OwnerName, string i_PhoneNumber, Dictionary<string, object> i_VehicleDetails, Dictionary<string, object> i_SpecialDict)
        {
            GarageENum.eAcceptedVehicleTypes type = (GarageENum.eAcceptedVehicleTypes)i_VehicleDetails["Energy type"];
            Bike newBike = null;
            i_VehicleDetails["Max wheels pressure"] = k_BikeMaxWheelAirPressure;
            switch (type)
            {
                case GarageENum.eAcceptedVehicleTypes.FuelBike:
                    i_VehicleDetails["Max energy"] = k_BikeMaxFuelLevel;
                    i_VehicleDetails["Energy type"] = GarageENum.eEnergyType.Octan96;
                    newBike = new Bike(i_VehicleDetails, i_SpecialDict);
                    break;
                case GarageENum.eAcceptedVehicleTypes.ElectricBike:
                    i_VehicleDetails["Max energy"] = k_BikeMaxBatteryLevel;
                    i_VehicleDetails["Energy type"] = GarageENum.eEnergyType.Electric;
                    newBike = new Bike(i_VehicleDetails, i_SpecialDict);
                    break;
            }

            i_Garage.AddVehicle(new VehicleInGarage(newBike, i_OwnerName, i_PhoneNumber, (GarageENum.eEnergyType)i_VehicleDetails["Energy type"]));
        }
    }
}
