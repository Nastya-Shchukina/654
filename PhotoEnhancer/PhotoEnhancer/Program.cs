using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficent
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters> (
                "Оттенки серого",
                (pixel, parameters) => 
                    {
                        var channel = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;
                        return new Pixel(channel, channel, channel);
                    }
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - 1 - point.X, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° против ч. с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            mainForm.AddFilter(new PixelFilter<HueParam>(
                "Сдвиг оттенка",
                (pixel, parameters) => Filters.HueChange.HueShift(pixel, parameters.Value)
                ));

            Application.Run(mainForm);
        }
    }
}
