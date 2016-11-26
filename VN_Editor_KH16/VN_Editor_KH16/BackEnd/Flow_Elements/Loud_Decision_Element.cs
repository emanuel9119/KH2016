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
        public int _output_count = 1;
        public int output_count {
            get { return _output_count; }
            set { _output_count = value;
                if (outputs.Count > _output_count)
                {
                    outputs.RemoveRange(_output_count, outputs.Count - _output_count);
                }else
                {
                    int wall = _output_count - outputs.Count;
                    for (int i = 0; i < wall; i++)
                    outputs.Add(null);
                }
            }
        }

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

            Polygon bal = new Polygon();

            if (this == MainWindow.selected)
                bal.Fill = System.Windows.Media.Brushes.LightYellow;
            else
                bal.Fill = System.Windows.Media.Brushes.LightCyan;

            bal.Stroke = System.Windows.Media.Brushes.Black;
           

            if (curr_king != null)
            {
                pic.MouseMove += sender_converter;
            }

            canvas.Children.Add(pic);

            switch (_output_count)
            {
                case 1:
                    for (int i = 0; i < 40; i++)
                        bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40), embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40) + 15));
                    canvas.Children.Add(bal);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

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
