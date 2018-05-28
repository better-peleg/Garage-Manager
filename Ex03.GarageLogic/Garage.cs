using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<VehicleInGarage> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new List<VehicleInGarage>();
        }

        internal void AddVehicle(VehicleInGarage i_toAdd)
        {
            m_Vehicles.Add(i_toAdd);
        }

        public void FillEnergy(string i_LicenseNumber, int i_TypeOfEnergy, float i_AmountToFill)
        {
            foreach (VehicleInGarage vehicle in Vehicles)
            {
                if (i_LicenseNumber.Equals(vehicle.ID))
                {
                    if (vehicle.Vehicle is Car)
                    {
                        ((Car)vehicle.Vehicle).FillEnergy((GarageENum.eEnergyType)i_TypeOfEnergy, i_AmountToFill);
                    }
                    else if (vehicle.Vehicle is Bike)
                    {
                        ((Bike)vehicle.Vehicle).FillEnergy((GarageENum.eEnergyType)i_TypeOfEnergy, i_AmountToFill);
                    }
                    else if (vehicle.Vehicle is Truck)
                    {
                        ((Truck)vehicle.Vehicle).FillEnergy((GarageENum.eEnergyType)i_TypeOfEnergy, i_AmountToFill);
                    }
                }
            }
        }

        public bool CarIsAlreadyInGarage(string i_LicenseNumber)
        {
            bool output = false;
            foreach (VehicleInGarage curVehicle in m_Vehicles)
            {
                if (i_LicenseNumber.Equals(curVehicle.ID))
                {
                    curVehicle.Status = GarageENum.eStatus.InRepair;
                    output = true;
                    break;
                }
            }

            return output;
        }

        public string VehcilesByStatusToString(int i_Status)
        {
            StringBuilder vehiclesList = new StringBuilder();
            foreach (VehicleInGarage vehicle in this.Vehicles)
            {
                if (i_Status == 0)
                {
                    vehiclesList.Append(vehicle.ID + Environment.NewLine);
                }
                else if (vehicle.Status == (GarageENum.eStatus)i_Status)
                {
                    vehiclesList.Append(vehicle.ID + Environment.NewLine);
                }
            }

            return vehiclesList.ToString();
        }

        public float CarMaxAirPressure()
        {
            return Ex03.GarageLogic.AddVehicle.CarMaxWheelAirPressure;
        }

        public float BikeMaxAirPressure()
        {
            return Ex03.GarageLogic.AddVehicle.BikeMaxWheelAirPressure;
        }

        public float TruckMaxAirPressure()
        {
            return Ex03.GarageLogic.AddVehicle.TruckMaxWheelAirPressure;
        }

        public void ChangeCarStatus(string i_LicenseNumber, int i_Status)
        {
            foreach (VehicleInGarage vehicle in Vehicles)
            {
                if (vehicle.ID.Equals(i_LicenseNumber))
                {
                    vehicle.Status = (GarageENum.eStatus)i_Status;
                }
            }
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            foreach (VehicleInGarage vehicle in Vehicles)
            {
                if (vehicle.ID.Equals(i_LicenseNumber))
                {
                    vehicle.Vehicle.InflateWheelsToMax();
                }
            }
        }

        public override string ToString()
        {
            string lineSeperator = Environment.NewLine + Environment.NewLine;
            StringBuilder garageInfo = new StringBuilder();
            foreach (VehicleInGarage vehicle in Vehicles)
            {
                garageInfo.Append(vehicle.ToString() + lineSeperator);
            }

            return garageInfo.ToString();
        }

        private string getEnumOptionsString<TEnum>()
        {
            StringBuilder output = new StringBuilder();
            string[] eNumList = Enum.GetNames(typeof(TEnum));
            for (int i = 1; i <= eNumList.Length; i++)
            {
                output.Append(i + ". " + eNumList[i - 1] + Environment.NewLine);
            }

            return output.ToString();
        }

        public string GetOptions(string i_Input)
        {
            string output;
            switch (i_Input)
            {
                case "Car color":
                    output = getEnumOptionsString<GarageENum.eCarColor>();
                    break;
                case "Number of doors":
                    output = "2, 3, 4, 5";
                    break;
                case "Biohazard":
                    output = "Yes / No";
                    break;
                case "License type":
                    output = getEnumOptionsString<GarageENum.eBikeLicenseType>();
                    break;
                default:
                    output = string.Empty;
                    break;
            }

            return output;
        }

        public string GetVehiclesTypes()
        {
            return getEnumOptionsString<GarageENum.eAcceptedVehicleTypes>();
        }

        public string GetEnergyTypes()
        {
            return getEnumOptionsString<GarageENum.eEnergyType>();
        }

        public string GetStatusOptions()
        {
            return getEnumOptionsString<GarageENum.eStatus>();
        }

        public int GetNumberOfAcceptedVehicle()
        {
            return Enum.GetNames(typeof(GarageENum.eAcceptedVehicleTypes)).Length;
        }

        public int GetNumberOfStatusOptions()
        {
            return Enum.GetNames(typeof(GarageENum.eStatus)).Length;
        }

        public int GetNumberOfColorsOptions()
        {
            return Enum.GetNames(typeof(GarageENum.eCarColor)).Length;
        }

        public int GetNumberOfBikeLicenseType()
        {
            return Enum.GetNames(typeof(GarageENum.eBikeLicenseType)).Length;
        }

        public int GetNumberOfEnergyType()
        {
            return Enum.GetNames(typeof(GarageENum.eEnergyType)).Length;
        }

        public List<VehicleInGarage> Vehicles { get => m_Vehicles; }
    }
}