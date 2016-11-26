using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class Loud_Decision_Element : Generic_Element
    {
        public List<Choice_Desc_Pair> outputs;

        public Loud_Decision_Element()
        {
            outputs = new List<Choice_Desc_Pair>();
        }

        public Loud_Decision_Element(Point loc)
        {
            embedding_location = loc;
        }

        public override void for_each_child(Action<Generic_Element> lambda)
        {
            outputs.ForEach(o =>
            {
                lambda(o.choice);
            });
        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {
            outputs.ForEach(o =>
            {
                lambda(o.choice);
                o.choice.for_each_descendant(lambda);
            });
        }

        public override int get_el_type()
        {
            return 2;
        }

        public override void print_el(Canvas canvas)
        {
            Polygon pic = new Polygon();
            pic.Fill = System.Windows.Media.Brushes.LightCyan;
            pic.Stroke = System.Windows.Media.Brushes.LightCyan;

            pic.Points.Add(new Point(embedding_location.X, embedding_location.Y + 60));
            pic.Points.Add(new Point(embedding_location.X + 60, embedding_location.Y));
            pic.Points.Add(new Point(embedding_location.X, embedding_location.Y - 60));
            pic.Points.Add(new Point(embedding_location.X - 60, embedding_location.Y));

            canvas.Children.Add(pic);
        }
    }

    

    public class Choice_Desc_Pair
    {
        public Generic_Element choice { get; set; }
        public string desc { get; set; }
    }
}
