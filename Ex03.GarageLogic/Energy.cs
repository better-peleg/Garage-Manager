using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Energy
    {
        private GarageENum.eEnergyType m_EnergyType;
        private float m_MaxEnergy;
        private float m_CurrentEnergyLeft;

        internal Energy(GarageENum.eEnergyType i_EnergyType, float i_MaxEnergy, float i_CurrentEnergyLeft)
        {
            this.m_EnergyType = i_EnergyType;
            this.m_MaxEnergy = i_MaxEnergy;
            this.m_CurrentEnergyLeft = i_CurrentEnergyLeft;
        }

        internal float MaxEnergy { get => m_MaxEnergy; set => m_MaxEnergy = value; }

        internal float CurrentEnergyLeft { get => m_CurrentEnergyLeft; set => m_CurrentEnergyLeft = value; }

        internal GarageENum.eEnergyType EnergyType { get => m_EnergyType; set => m_EnergyType = value; }

        internal string EnergyDetails()
        {
            string energyDetails;
            switch (EnergyType)
            {
                case GarageENum.eEnergyType.Electric:
                    energyDetails = string.Format(
@"Energy type: {0}, Max battery time is: {1} hours, Current battery left: {2} hours.",
EnergyType,
MaxEnergy, 
CurrentEnergyLeft);
                    break;
                default:
                    energyDetails = string.Format(
@"Fuel type: {0}, Max fuel capacity: {1} Litres, Current fuel left: {2} Litres.",
EnergyType,
MaxEnergy,
CurrentEnergyLeft);
                    break;
            }

            return energyDetails;
        }

        internal bool FillEnergy(GarageENum.eEnergyType i_TypeOfFuel, float i_AmountToFill)
        {
            bool output = false;
            if (!i_TypeOfFuel.Equals(EnergyType))
            {
                throw new ArgumentException("Invalid energy type");
            }
            else if (i_AmountToFill + CurrentEnergyLeft > MaxEnergy)
            {
                throw new ValueOutOfRangeException(MaxEnergy - CurrentEnergyLeft, 0);
            }
            else
            {
                output = true;
                CurrentEnergyLeft = CurrentEnergyLeft + i_AmountToFill;
                return output;
            }
        }
    }
}
