using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base(string.Format(@"Invalid value. Value must be between {0} and {1}.", i_MinValue, i_MaxValue))
        {
            MaxValue = i_MinValue;
            MinValue = i_MinValue;
        }

        public float MaxValue { get => m_MaxValue; set => m_MaxValue = value; }

        public float MinValue { get => m_MinValue; set => m_MinValue = value; }
    }
}
