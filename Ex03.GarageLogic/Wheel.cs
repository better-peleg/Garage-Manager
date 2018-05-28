using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentPressure;
        private float m_MaxPressure;

        internal static Wheel[] InitiateWheelsArray(int i_NumberOfWheels, string i_WheelManufacturer, float i_WheelCurrentPressure, float i_WheelMaxPressure)
        {
            Wheel[] output = new Wheel[i_NumberOfWheels];
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                output[i] = new Wheel(i_WheelManufacturer, i_WheelCurrentPressure, i_WheelMaxPressure);
            }

            return output;
        }

        internal Wheel(string i_Manufacturer, float i_CurrentPressure, float i_MaxPressure)
        {
            this.m_Manufacturer = i_Manufacturer;
            this.m_CurrentPressure = i_CurrentPressure;
            this.m_MaxPressure = i_MaxPressure;
        }

        internal void Inflate(float i_PressureToAdd)
        {
            if (i_PressureToAdd + m_CurrentPressure > m_MaxPressure)
            {
                throw new ValueOutOfRangeException(m_MaxPressure - m_CurrentPressure, 0);
            }
            else
            {
                m_CurrentPressure = i_PressureToAdd + m_CurrentPressure;
            }
        }

        internal string Manufacturer { get => m_Manufacturer; set => m_Manufacturer = value; }

        internal float MaxPressure { get => m_MaxPressure; set => m_MaxPressure = value; }

        internal void MaxInflate()
        {
            this.CurrentPressure = m_MaxPressure;
        }

        internal float CurrentPressure { get => m_CurrentPressure; set => m_CurrentPressure = value; }
    }
}
