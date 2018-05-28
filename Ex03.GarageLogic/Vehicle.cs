using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {             
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyLevel;
        private Wheel[] m_Wheels;

        internal static Dictionary<string, object> CreateVehicleDictionary()
        {
            Dictionary<string, object> output = new Dictionary<string, object>
            {
                { "Model name", null },
                { "Energy type", null },
                { "Max energy", null },
                { "Current energy(%)", null },
                { "License number", null },
                { "Wheels manufacturer", null },
                { "Current wheels pressure", null },
                { "Max wheels pressure", null }
            };
            return output;
        }

        internal Vehicle(Dictionary<string, object> i_VehicleDic)
        {
            m_ModelName = (string)i_VehicleDic["Model name"];
            m_EnergyLevel = (float)i_VehicleDic["Current energy(%)"];
            m_LicenseNumber = (string)i_VehicleDic["License number"];
        }

        internal abstract void SetSpecialProperties(Dictionary<string, object> i_SpecialProperties);      

        internal void InflateWheelsToMax()
        {
            for (int i = 0; i < Wheels.Length; i++)
            {
                m_Wheels[i].MaxInflate();
            }
        }

        internal Wheel[] Wheels { get => m_Wheels; set => m_Wheels = value; }

        internal string ModelName { get => m_ModelName; set => m_ModelName = value; }

        internal string LicenseNumber { get => m_LicenseNumber; set => m_LicenseNumber = value; }

        internal float EnergyLevel { get => m_EnergyLevel; set => m_EnergyLevel = value; }

        internal virtual string WheelsDetails()
        {
            string output = string.Format(
@"Wheels Manufacturer: {0}, max air pressure: {1}, current air pressure: {2}.",
                    m_Wheels[0].Manufacturer,
                    m_Wheels[0].MaxPressure,
                    m_Wheels[0].CurrentPressure);
            return output;
        }

        internal virtual string VehicleDetails()
        {
            string output = string.Format(
@"Model name: {0}, License number: {1}, current energy level: {2}%. {3}{4}",
                            ModelName, 
                            LicenseNumber,
                            EnergyLevel,
                            Environment.NewLine,
                            WheelsDetails());

            return output;
        }
    }
}
