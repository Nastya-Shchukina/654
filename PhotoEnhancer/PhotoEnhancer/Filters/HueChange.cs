using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters
{
    class HueChange
    {
        public static Pixel HueShift(Pixel p, double shift)
        {
            HSLPixel temp = Convertors.RGBtoHSL(p);
            double h = temp.Hue + shift;
            if (h > 360) h -= 360;
            temp.Hue = h;
            return Convertors.HSLtoRGB(temp);
        }
    }
}
