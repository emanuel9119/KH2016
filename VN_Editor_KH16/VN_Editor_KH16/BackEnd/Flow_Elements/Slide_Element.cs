using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Input;

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
            if (output != null)
            {
                lambda(output);
            }
        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {
            if (output != null)
            {
                lambda(output);
                output.for_each_descendant(lambda);
            }
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

        public override void print_el(ref Canvas canvas)
        {
            Polygon pic = new Polygon();

            if (this == MainWindow.selected)
                pic.Fill = System.Windows.Media.Brushes.LightYellow;
            else
                pic.Fill = System.Windows.Media.Brushes.LightCyan;
            
            pic.Stroke = System.Windows.Media.Brushes.Black;

            pic.Points.Add(new Point(embedding_location.X - 10, embedding_location.Y + 10));
            pic.Points.Add(new Point(embedding_location.X + 10, embedding_location.Y + 10));
            pic.Points.Add(new Point(embedding_location.X + 10, embedding_location.Y - 10));
            pic.Points.Add(new Point(embedding_location.X - 10, embedding_location.Y - 10));


            Polygon bal = new Polygon();

            if (this == MainWindow.selected)
                bal.Fill = System.Windows.Media.Brushes.LightYellow;
            else
                bal.Fill = System.Windows.Media.Brushes.LightCyan;

            bal.Stroke = System.Windows.Media.Brushes.Black;

            for (int i = 0; i < 40; i++)
                bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40), embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40)+10));


            pic.MouseLeftButtonDown += new_selected;

            if (curr_king != null)
            {
                pic.MouseMove += sender_converter;
            }

            canvas.Children.Add(pic);
            canvas.Children.Add(bal);
        }

        public override void print_cn(ref Canvas canvas)
        {
            if (output != null)
            {
                Line ln = new Line();
                ln.Stroke = System.Windows.Media.Brushes.Black;

                ln.X1 = embedding_location.X;
                ln.Y1 = embedding_location.Y;

                ln.X2 = output.embedding_location.X;
                ln.Y2 = output.embedding_location.Y;

                canvas.Children.Add(ln);
            }
        }

        public string speaker  { get; set; }
        public string dialogue { get; set; }
        public string dev_note { get; set; }
    }
}
