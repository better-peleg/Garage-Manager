using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{    
    internal class Bike : Vehicle
    {
        private GarageENum.eBikeLicenseType m_LicenseType;
        private int m_EngineDisplacement;
        private Energy m_Energy;

        internal static Dictionary<string, object> BikeSpecialPropertiesDictionary()
        {
            Dictionary<string, object> output = new Dictionary<string, object>
            {
                { "License type", null },
                { "Engine displacement", null }
            };
            return output;
        }

        internal Bike(Dictionary<string, object> i_VehicleDic, Dictionary<string, object> i_SpecialProperties)
            : base(i_VehicleDic)
        {
            m_Energy = new Energy((GarageENum.eEnergyType)i_VehicleDic["Energy type"], (float)i_VehicleDic["Max energy"], (float)i_VehicleDic["Max energy"] * (float)i_VehicleDic["Current energy(%)"] / 100);
            Wheels = Wheel.InitiateWheelsArray(2, (string)i_VehicleDic["Wheels manufacturer"], (float)i_VehicleDic["Current wheels pressure"], (float)i_VehicleDic["Max wheels pressure"]);
            SetSpecialProperties(i_SpecialProperties);
        }

        internal override void SetSpecialProperties(Dictionary<string, object> i_SpecialProperties)
        {
            int LicenseTypeMaxIndex = Enum.GetNames(typeof(GarageENum.eBikeLicenseType)).Length;
            this.m_LicenseType = (GarageENum.eBikeLicenseType)Validation.IntValueInRange(1, LicenseTypeMaxIndex, (string)i_SpecialProperties["License type"]);
            this.m_EngineDisplacement = Validation.IntValueInRange(0, int.MaxValue, (string)i_SpecialProperties["Engine displacement"]);
        }      

        public int EngineDisplacement { get => m_EngineDisplacement; set => m_EngineDisplacement = value; }

        internal GarageENum.eBikeLicenseType LicenseType { get => m_LicenseType; set => m_LicenseType = value; }

        internal Energy Energy { get => m_Energy; set => m_Energy = value; }

        internal void FillEnergy(GarageENum.eEnergyType i_TypeOfFuel, float i_AmountToFill)
        {
            bool success = this.Energy.FillEnergy(i_TypeOfFuel, i_AmountToFill);
            if (success)
            {
                this.EnergyLevel = (Energy.CurrentEnergyLeft / Energy.MaxEnergy) * 100;
            }
        }

        internal override string VehicleDetails()
        {
            string carDetails = string.Format(
@"{0}
{1}
Bike license is: {2}, Engine displacement is: {3}cc",
base.VehicleDetails(),
Energy.EnergyDetails(),
LicenseType,
EngineDisplacement);
            return carDetails;
        }
    }
}
