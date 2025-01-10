using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace _3D_Chart_WPF_v1
{
    internal class Axis
    {
        static double width, height;
        Pen pen;

        public Axis(double w, double h)
        {
            width = w;
            height = h;

            pen = new Pen(Brushes.Black, 0.5);
        }

        public void Draw(DrawingContext dc, Brush brush)
        {
            pen.Brush = brush;

            // axis X
            dc.DrawLine(pen, new Point(0, height / 2), new Point(width, height / 2));

            // axis Y
            dc.DrawLine(pen, new Point(width / 2, 0), new Point(width / 2, height));

            // X ortha text
            FormattedText formattedText = new FormattedText("X", CultureInfo.GetCultureInfo("en-us"),
                                                FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.Black,
                                                VisualTreeHelper.GetDpi(MainWindow.visual).PixelsPerDip);
            Point textPos = new Point(width - 14, height / 2 - 20);
            dc.DrawText(formattedText, textPos);

            // Y ortha text
            formattedText = new FormattedText("Y", CultureInfo.GetCultureInfo("en-us"),
                                                FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.Black,
                                                VisualTreeHelper.GetDpi(MainWindow.visual).PixelsPerDip);
            textPos = new Point(width / 2 + 6, 6);
            dc.DrawText(formattedText, textPos);
        }
    }
}
