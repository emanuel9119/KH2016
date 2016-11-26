using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;

namespace VN_Editor_KH16
{
    public class Shapes : UserControl
    {
        public static Polygon loud_decision { get; set; } = new Polygon();
        public static Polygon group { get; set; } = new Polygon();
        public static Polygon slide { get; set; } = new Polygon();
        public static Polygon end { get; set; } = new Polygon();
        
        public Shapes ()
        {
            for (int i = 0; i < 40; i++)
                end.Points.Add(new Point(10 * Math.Cos(2 * Math.PI * i / 40), 10 * Math.Sin(2 * Math.PI * i / 40)));

            group.Points.Add(new Point(14, -10));
            group.Points.Add(new Point(-14, -10));
            group.Points.Add(new Point(-14, 10));
            group.Points.Add(new Point(14, 10));

            loud_decision.Points.Add(new Point(0, 14));
            loud_decision.Points.Add(new Point(14, 0));
            loud_decision.Points.Add(new Point(0, -14));
            loud_decision.Points.Add(new Point(-14, 0));

            slide.Points.Add(new Point(-10, 10));
            slide.Points.Add(new Point(10, 10));
            slide.Points.Add(new Point(10, -10));
            slide.Points.Add(new Point(-10, -10));
        }
    }
}
