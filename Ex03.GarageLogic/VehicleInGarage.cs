using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private GarageENum.eStatus m_Status;
        private GarageENum.eEnergyType m_EnergyType;

        internal VehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone, GarageENum.eEnergyType i_EnergyType)
        {
            this.m_EnergyType = i_EnergyType;
            this.m_Vehicle = i_Vehicle;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
            this.m_Status = GarageENum.eStatus.InRepair;
        }

        internal string ID { get => m_Vehicle.LicenseNumber; }

        internal string OwnerName { get => m_OwnerName; set => m_OwnerName = value; }

        internal string OwnerPhone { get => m_OwnerPhone; set => m_OwnerPhone = value; }

        internal GarageENum.eStatus Status { get => m_Status; set => m_Status = value; }

        internal Vehicle Vehicle { get => m_Vehicle; set => m_Vehicle = value; }

        internal GarageENum.eEnergyType EnergyType { get => m_EnergyType; set => m_EnergyType = value; }

        public static void AddNewVehicle(Garage i_Garage, string i_Name, string i_PhoneNumber, Dictionary<string, object> i_VehicleDic, Dictionary<string, object> i_SpecialProperties)
        {
            GarageENum.eAcceptedVehicleTypes type = (GarageENum.eAcceptedVehicleTypes)i_VehicleDic["Energy type"];
            switch (type)
            {
                case GarageENum.eAcceptedVehicleTypes.FuelCar: /// same cases for electric and fuel car
                case GarageENum.eAcceptedVehicleTypes.ElectricCar:
                    AddVehicle.AddCar(i_Garage, i_Name, i_PhoneNumber, i_VehicleDic, i_SpecialProperties);
                    break;
                case GarageENum.eAcceptedVehicleTypes.FuelBike: /// same cases for electric and fuel bike
                case GarageENum.eAcceptedVehicleTypes.ElectricBike:
                    AddVehicle.AddBike(i_Garage, i_Name, i_PhoneNumber, i_VehicleDic, i_SpecialProperties);
                    break;
                case GarageENum.eAcceptedVehicleTypes.FuelTruck: /// for truck
                    AddVehicle.AddTruck(i_Garage, i_Name, i_PhoneNumber, i_VehicleDic, i_SpecialProperties);
                    break;
            }
        }

        public static Dictionary<string, object> GetVehicleDictionary()
        {
            return Vehicle.CreateVehicleDictionary();
        }

        public override string ToString()
        {
            string vehicleInGarageInfo = string.Format(
@"Vehicle Owner: {0}, Owner Phone number: {1}, Vehicle status: {2}
{3}",
this.OwnerName,
this.OwnerPhone,
this.Status,
this.Vehicle.VehicleDetails());
            return vehicleInGarageInfo;
        }       
    }
}
