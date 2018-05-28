using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private Energy m_Energy;
        private bool m_Biohazard;
        private float m_MaxCarryWeight;

        internal static Dictionary<string, object> TruckSpecialPropertiesDictionary()
        {
            Dictionary<string, object> output = new Dictionary<string, object>
            {
                { "Biohazard", null },
                { "Max carry weight", null }
            };
            return output;
        }

        internal Truck(Dictionary<string, object> i_CarDic, Dictionary<string, object> i_SpecialProperties)
            : base(i_CarDic)
        {
            m_Energy = new Energy((GarageENum.eEnergyType)i_CarDic["Energy type"], (float)i_CarDic["Max energy"], (float)i_CarDic["Max energy"] * (float)i_CarDic["Current energy(%)"] / 100);
            Wheels = Wheel.InitiateWheelsArray(12, (string)i_CarDic["Wheels manufacturer"], (float)i_CarDic["Current wheels pressure"], (float)i_CarDic["Max wheels pressure"]);
            this.SetSpecialProperties(i_SpecialProperties);            
        }

        internal override void SetSpecialProperties(Dictionary<string, object> i_SpecialProperties)
        {
            this.m_Biohazard = Validation.GetBiohazard((string)i_SpecialProperties["Biohazard"]);
            this.m_MaxCarryWeight = Validation.FloatValueInRange(0, float.MaxValue, (string)i_SpecialProperties["Max carry weight"]);
        }        

        public bool Biohazard { get => m_Biohazard; set => m_Biohazard = value; }

        public float MaxCarryWeight { get => m_MaxCarryWeight; set => m_MaxCarryWeight = value; }

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
            string truckDetails;
            if (Biohazard)
            {
                truckDetails = string.Format(
@"{0}
{1}
The truck carries hazardous content, Truck's maximum carry weight: {2}",
base.VehicleDetails(),
Energy.EnergyDetails(),
MaxCarryWeight);
            }
            else
            {
                truckDetails = string.Format(
@"{0}
{1}
The truck does not carry hazardous content, Truck's maximum carry weight: {2}",
base.VehicleDetails(),
Energy.EnergyDetails(),
MaxCarryWeight);
            }

            return truckDetails;
        }
    }
}
