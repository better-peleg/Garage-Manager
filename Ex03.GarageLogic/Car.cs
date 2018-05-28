using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private GarageENum.eCarColor m_CarColor;
        private GarageENum.eNumberOfDoors m_NumberOfDoors;
        private Energy m_Energy;

        internal static Dictionary<string, object> CarSpecialPropertiesDictionary()
        {
            Dictionary<string, object> output = new Dictionary<string, object>
            {
                { "Car color", null },
                { "Number of doors", null }
            };
            return output;
        }

        internal Car(Dictionary<string, object> i_CarDic, Dictionary<string, object> i_SpecialProperties)
            : base(i_CarDic)
        {
            m_Energy = new Energy((GarageENum.eEnergyType)i_CarDic["Energy type"], (float)i_CarDic["Max energy"], (float)i_CarDic["Max energy"] * (float)i_CarDic["Current energy(%)"] / 100);
            Wheels = Wheel.InitiateWheelsArray(4, (string)i_CarDic["Wheels manufacturer"], (float)i_CarDic["Current wheels pressure"], (float)i_CarDic["Max wheels pressure"]);
            this.SetSpecialProperties(i_SpecialProperties);
        }        

        internal override void SetSpecialProperties(Dictionary<string, object> i_CarSpecialPropertiesDictionary)
        {
            int carColorsMaxIndex = Enum.GetNames(typeof(GarageENum.eCarColor)).Length;
            int numbOfDoorsMaxIndex = Enum.GetNames(typeof(GarageENum.eNumberOfDoors)).Length;
            this.m_CarColor = (GarageENum.eCarColor)Validation.IntValueInRange(1, carColorsMaxIndex, (string)i_CarSpecialPropertiesDictionary["Car color"]);
            this.m_NumberOfDoors = (GarageENum.eNumberOfDoors)Validation.IntValueInRange(2, numbOfDoorsMaxIndex, (string)i_CarSpecialPropertiesDictionary["Number of doors"]);
        }
       
        internal Energy Energy { get => m_Energy; set => m_Energy = value; }

        internal GarageENum.eCarColor CarColor { get => m_CarColor; set => m_CarColor = value; }

        internal GarageENum.eNumberOfDoors NumberOfDoors { get => m_NumberOfDoors; set => m_NumberOfDoors = value; }

        internal void FillEnergy(GarageENum.eEnergyType i_TypeOfFuel, float i_AmountToFill)
        {
            bool success = this.Energy.FillEnergy(i_TypeOfFuel, i_AmountToFill);
            if(success)
            {
                this.EnergyLevel = (Energy.CurrentEnergyLeft / Energy.MaxEnergy) * 100;
            }
        }
        
        internal override string VehicleDetails()
        {
            string carDetails = string.Format(
@"{0}
{1}
Car color is: {2}, Number of doors: {3}",
base.VehicleDetails(),
Energy.EnergyDetails(),
CarColor,
NumberOfDoors);
            return carDetails;
        }
    }
}