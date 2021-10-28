using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class HueParam : IParameters
    {
        public double Value { get; set; }

        public ParameterInfo[] GetDisciption()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Значение",
                    MinValue = 0,
                    MaxValue = 360,
                    DefaultValue = 0,
                    Increment = 1
                }
            };
        }

        public void SetValues(double[] values)
        {
            Value = values[0];
        }
    }
}
