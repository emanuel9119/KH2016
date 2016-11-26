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

        public List<Slide_Element> get_streak()
        {
            List<Slide_Element> returnable = new List<Slide_Element>();
            Generic_Element next = this;

            while (next.inputs.Count == 1)
            {
                if (next.inputs[0].get_el_type() == 1)
                    next = next.inputs[0];
                else
                    break;
            }

            while (next.get_el_type() == 1)
            {
                returnable.Add((Slide_Element)next);
                next = ((Slide_Element)next).output;
                if (next == null)
                    break;
            }

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


            pic.MouseRightButtonDown += new_selected;

            if (curr_king != null)
            {
                pic.MouseMove += sender_converter;
            }

            pic.AllowDrop = true;
            pic.Drop += drop_handler;
            bal.MouseMove += slide_mousemv;

            canvas.Children.Add(pic);
            canvas.Children.Add(bal);
        }

        public void slide_mousemv(object sender, MouseEventArgs args)
        {
            curr_king.rw_slide_MouseMove(this, args);
        }

        public override void print_cn(ref Canvas canvas)
        {
            if (output != null)
            {
                Line ln = new Line();
                ln.Stroke = System.Windows.Media.Brushes.Black;

                ln.X1 = embedding_location.X;
                ln.Y1 = embedding_location.Y + 10;

                ln.X2 = output.embedding_location.X;
                if (output.get_el_type() == 2)
                    ln.Y2 = output.embedding_location.Y - 14;
                else if (output.get_el_type() == 4)
                    ln.Y2 = output.embedding_location.Y;
                else
                    ln.Y2 = output.embedding_location.Y - 10;

                canvas.Children.Add(ln);
            }
        }

        public string speaker  { get; set; }
        public string dialogue { get; set; }
        public string dev_note { get; set; }
    }
}
