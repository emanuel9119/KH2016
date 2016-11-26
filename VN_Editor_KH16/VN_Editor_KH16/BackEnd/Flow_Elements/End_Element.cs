using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class End_Element : Generic_Element
    {
        Group_Element master;
        int End_El_Num;

        public End_Element()
        {
            master = null;
        }

        public End_Element(Point loc)
        {
            embedding_location = loc;
        }

        public override void for_each_child(Action<Generic_Element> lambda)
        {

        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {

        }

        public override int get_el_type()
        {
            return 4;
        }
        
        public override void print_el(Canvas canvas)
        {
            Polygon pic = new Polygon();
            pic.Fill = System.Windows.Media.Brushes.LightCyan;
            pic.Stroke= System.Windows.Media.Brushes.LightCyan;

            for (int i = 0; i < 40; i++)
                pic.Points.Add(new Point(embedding_location.X + 40 * Math.Cos(2*Math.PI*i/40), embedding_location.Y + 40 * Math.Sin(2 * Math.PI * i / 40)));

            canvas.Children.Add(pic);
        }
    }
}
