using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public struct HSLPixel
    {
        double h;
        public double Hue
        {
            get { return h; }

            set { h = CheckValueH(value); }
        }

        double s;
        public double Saturation
        {
            get { return s; }

            set { s = CheckValue(value); }
        }

        double l;
        public double Lightness
        {
            get { return l; }

            set { l = CheckValue(value); }
        }

        public HSLPixel(double hue, double saturation, double lightness) : this()
        {
            h = hue;
            s = saturation;
            l = lightness;
        }

        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new ArgumentException($"Неверное значение {val}. Нужно от 0 до 1");
            return val;
        }

        private double CheckValueH(double val)
        {
            if (val > 360 || val < 0)
                throw new ArgumentException($"Неверное значение {val}. Нужно от 0 до 360");
            return val;
        }
    }
}
