using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class GarageENum
    {
        internal enum eAcceptedVehicleTypes
        {
            FuelCar = 1, ElectricCar = 2, FuelBike = 3, ElectricBike = 4, FuelTruck = 5
        }

        internal enum eBikeLicenseType
        {
            A, A1, B1, B2
        }

        internal enum eCarColor
        {
            Grey = 1, Blue = 2, Black = 3, White = 4
        }

        internal enum eNumberOfDoors
        {
            Two = 2, Three = 3, Four = 4, Five = 5
        }

        internal enum eEnergyType
        {
            Soler = 1, Octan95 = 2, Octan96 = 3, Octan98 = 4, Electric = 5
        }

        internal enum eStatus
        {
            InRepair = 1, Fixed = 2, Paid = 3
        }
    }
}
