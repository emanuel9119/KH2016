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
    public class Slide_Element : Generic_Element
    {
        public Generic_Element output;

        public Slide_Element()
        {
            output = null;
        }

        public Slide_Element(Point loc)
        {
            embedding_location = loc;
        }

        public override void for_each_child(Action<Generic_Element> lambda)
        {
            lambda(output);
        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {
            lambda(output);
            output.for_each_descendant(lambda);
        }

        public override int get_el_type()
        {
            return 1;
        }

        public List<Slide_Element> get_streak(ref Generic_Element new_head)
        {
            List<Slide_Element> returnable = new List<Slide_Element>();
            Slide_Element curr = this;

            do
            {
                returnable.Add(curr);
                if (curr.output == null)
                {
                    new_head = null;
                    curr = null;
                }else if (curr.output.get_el_type() == 1 && curr.output.inputs.Count <= 1)
                    curr = (Slide_Element)curr.output;
                else {
                    new_head = curr.output;
                    curr = null;
                }
            } while (curr != null);

            return returnable;
        }

        public override void print_el(Canvas canvas)
        {
            Polygon pic = new Polygon();
            pic.Fill = System.Windows.Media.Brushes.LightCyan;
            pic.Stroke = System.Windows.Media.Brushes.LightCyan;

            pic.Points.Add(new Point(embedding_location.X - 40, embedding_location.Y + 40));
            pic.Points.Add(new Point(embedding_location.X + 40, embedding_location.Y + 40));
            pic.Points.Add(new Point(embedding_location.X + 40, embedding_location.Y - 40));
            pic.Points.Add(new Point(embedding_location.X - 40, embedding_location.Y - 40));

            canvas.Children.Add(pic);
        }

        public string speaker  { get; set; }
        public string dialogue { get; set; }
        public string dev_note { get; set; }
    }
}
