using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PhotoEnhancer
{
    public static class Convertors
    {
        public static Photo Bimap2Photo(Bitmap bmp)
        {
            var result = new Photo(bmp.Width, bmp.Height);
            
            for(var x = 0; x < bmp.Width; x++)
                for(var y = 0; y < bmp.Height; y++)
                {
                    var pixel = bmp.GetPixel(x, y);

                    result[x, y] = new Pixel(
                        (double)pixel.R / 255,
                        (double)pixel.G / 255,
                        (double)pixel.B / 255
                        );
                }

            return result;
        }

        public static Bitmap Photo2Bitmap(Photo photo)
        {
            var result = new Bitmap(photo.Width, photo.Height);

            for (var x = 0; x < photo.Width; x++)
                for(var y = 0; y < photo.Height; y++)
                    result.SetPixel(x, y, Color.FromArgb(
                        (int)Math.Round(photo[x, y].R * 255),
                        (int)Math.Round(photo[x, y].G * 255),
                        (int)Math.Round(photo[x, y].B * 255)
                        ));

            return result;      
        }

        public static HSLPixel RGBtoHSL(Pixel p)
        {
            //алгоритм взят тут: https://ru.wikipedia.org/wiki/HSL
            double max = new double[] { p.R, p.G, p.B }.Max();
            double min = new double[] { p.R, p.G, p.B }.Min();
            double l = (max + min) / 2;
            double s = 0;
            if (l == 0 || max == min) s = 0;
            else if (l <= 0.5) s = (max - min) / (max + min);
            else if (l > 0.5) s = (max - min) / (2 - max - min);
            double h = 0;
            if (max == min) h = 0;
            else if (max == p.R)
                if (p.G >= p.B) h = 60 * ((p.G - p.B) / (max - min));
                else h = 60 * ((p.G - p.B) / (max - min)) + 360;
            else if (max == p.G) h = 60 * ((p.B - p.R) / (max - min)) + 120;
            else if (max == p.B) h = 60 * ((p.R - p.G) / (max - min)) + 240;
            return new HSLPixel(h, s, l);
        }

        public static Pixel HSLtoRGB(HSLPixel px)
        {
            //алгоритм взят тут: https://ru.wikipedia.org/wiki/HSL
            double h = px.Hue / 360; 
            double q = 0;
            if (px.Lightness < 0.5) q = px.Lightness * (px.Saturation + 1);
            else q = px.Lightness + px.Saturation - (px.Lightness * px.Saturation);
            double p = px.Lightness * 2 - q;
            double[] rgb = new double[] { h + 1.0 / 3, h, h - 1.0 / 3 };
            if (rgb[0] > 1) rgb[0] -= 1;
            if (rgb[2] < 0) rgb[2] += 1;
            for (int i = 0; i < 3; i++)
                if (rgb[i] < 1.0 / 6) rgb[i] = p + ((q - p) * 6 * rgb[i]);
                else if (rgb[i] < 0.5) rgb[i] = q;
                else if (rgb[i] < 2.0 / 3) rgb[i] = p + ((q - p) * (2.0 / 3 - rgb[i]) * 6);
                else rgb[i] = p;
            return new Pixel(rgb[0], rgb[1], rgb[2]);
        }
    }
}
