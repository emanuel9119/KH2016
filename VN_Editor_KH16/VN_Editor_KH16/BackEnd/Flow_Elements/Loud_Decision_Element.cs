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

        public override void print_el(ref Canvas canvas)
        {
            Polygon pic = new Polygon();

            if (this == MainWindow.selected)
                pic.Fill = System.Windows.Media.Brushes.LightYellow;
            else
                pic.Fill = System.Windows.Media.Brushes.LightCyan;

            pic.Stroke = System.Windows.Media.Brushes.Black;

            pic.Points.Add(new Point(embedding_location.X, embedding_location.Y + 14));
            pic.Points.Add(new Point(embedding_location.X + 14, embedding_location.Y));
            pic.Points.Add(new Point(embedding_location.X, embedding_location.Y - 14));
            pic.Points.Add(new Point(embedding_location.X - 14, embedding_location.Y));

            pic.MouseLeftButtonDown += new_selected;

            canvas.Children.Add(pic);
        }

        public override void print_cn(ref Canvas canvas)
        {
            for (int i = 0; i < outputs.Count; i++)
           {
               Line ln = new Line();
               ln.Stroke = System.Windows.Media.Brushes.Black;

               ln.X1 = embedding_location.X;
               ln.Y1 = embedding_location.Y;

               ln.X2 = outputs[i].choice.embedding_location.X;
               ln.Y2 = outputs[i].choice.embedding_location.Y;

               canvas.Children.Add(ln);
           }
        }
    }

    

    public class Choice_Desc_Pair
    {
        public Generic_Element choice { get; set; }
        public string desc { get; set; }
    }
}
