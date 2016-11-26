using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class Loud_Decision_Element : Generic_Element
    {
        public List<Choice_Desc_Pair> outputs;
        public int _output_count = 1;
        public int output_count {
            get { return _output_count; }
            set { _output_count = value % 10;
                if (outputs.Count > _output_count)
                {
                    outputs.RemoveRange(_output_count, outputs.Count - _output_count);
                }else
                {
                    int wall = _output_count - outputs.Count;
                    for (int i = 0; i < wall; i++)
                    outputs.Add(new Choice_Desc_Pair() { owner = this, desc = "", choice = null });
                }
            }
        }

        public Loud_Decision_Element()
        {
            outputs = new List<Choice_Desc_Pair>();
            outputs.Add(new Choice_Desc_Pair() { owner = this, desc = "", choice = null });
        }

        public Loud_Decision_Element(Point loc)
        {
            embedding_location = loc;
            outputs = new List<Choice_Desc_Pair>();
            outputs.Add(new Choice_Desc_Pair() { owner = this, desc = "", choice = null });
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


            pic.MouseRightButtonDown += new_selected;

            pic.Drop += drop_handler;



            if (curr_king != null)
            {
                pic.MouseMove += sender_converter;
            }

            canvas.Children.Add(pic);
            
            Polygon bal = new Polygon();

            if (this == MainWindow.selected)
                bal.Fill = System.Windows.Media.Brushes.LightYellow;
            else
                bal.Fill = System.Windows.Media.Brushes.LightCyan;

            bal.Stroke = System.Windows.Media.Brushes.Black;
            switch (_output_count)
            {
                case 1:
                    for (int i = 0; i < 40; i++)
                        bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40), embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40) + 15));
                    if (curr_king != null)
                    {
                        bal.MouseMove += outputs[0].rewire;
                    }

                    canvas.Children.Add(bal);
                    break;
                case 2:
                    for (int i = 0; i < 40; i++)
                        bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40)+7.5, embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40) + 7.5));
                    if (curr_king != null)
                    {
                        bal.MouseMove += outputs[0].rewire;
                    }

                    canvas.Children.Add(bal);

                    bal = new Polygon();

                    if (this == MainWindow.selected)
                        bal.Fill = System.Windows.Media.Brushes.LightYellow;
                    else
                        bal.Fill = System.Windows.Media.Brushes.LightCyan;

                    bal.Stroke = System.Windows.Media.Brushes.Black;

                    for (int i = 0; i < 40; i++)
                        bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40) - 7.5, embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40) + 7.5));
                    if (curr_king != null)
                    {
                        bal.MouseMove += outputs[1].rewire;
                    }

                    canvas.Children.Add(bal);
                    break;
                case 3:
                    for (int i = 0; i < 40; i++)
                        bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40) + 15, embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40)));
                    if (curr_king != null)
                    {
                        bal.MouseMove += outputs[0].rewire;
                    }
                    canvas.Children.Add(bal);

                    bal = new Polygon();

                    if (this == MainWindow.selected)
                        bal.Fill = System.Windows.Media.Brushes.LightYellow;
                    else
                        bal.Fill = System.Windows.Media.Brushes.LightCyan;

                    bal.Stroke = System.Windows.Media.Brushes.Black;

                    for (int i = 0; i < 40; i++)
                        bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40) - 15, embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40)));
                    if (curr_king != null)
                    {
                        bal.MouseMove += outputs[1].rewire;
                    }
                    canvas.Children.Add(bal);

                    bal = new Polygon();

                    if (this == MainWindow.selected)
                        bal.Fill = System.Windows.Media.Brushes.LightYellow;
                    else
                        bal.Fill = System.Windows.Media.Brushes.LightCyan;

                    bal.Stroke = System.Windows.Media.Brushes.Black;

                    for (int i = 0; i < 40; i++)
                        bal.Points.Add(new Point(embedding_location.X + 5 * Math.Cos(2 * Math.PI * i / 40), embedding_location.Y + 5 * Math.Sin(2 * Math.PI * i / 40)+15));
                    if (curr_king != null)
                    {
                        bal.MouseMove += outputs[2].rewire;
                    }
                    canvas.Children.Add(bal);
                    break;
            }

        }

        public override void print_cn(ref Canvas canvas)
        {
            for (int i = 0; i < outputs.Count; i++)
           {
               Line ln = new Line();
               ln.Stroke = System.Windows.Media.Brushes.Black;

                if (output_count == 1 || output_count == 3 && i == 1)
                {
                    ln.X1 = embedding_location.X;
                    ln.Y1 = embedding_location.Y + 14;
                }
                else if (output_count == 2)
                {
                    ln.X1 = embedding_location.X + (i == 0 ? 7 : -7);
                    ln.Y1 = embedding_location.Y + 7;
                }
                else
                {
                    ln.X1 = embedding_location.X + (i == 0 ? 14 : -14);
                    ln.Y1 = embedding_location.Y;

                }

                ln.X2 = outputs[i].choice.embedding_location.X;
                if (outputs[i].choice.get_el_type() == 2)
                    ln.Y2 = outputs[i].choice.embedding_location.Y - 14;
                else if (outputs[i].choice.get_el_type() == 4)
                    ln.Y2 = outputs[i].choice.embedding_location.Y;
                else
                    ln.Y2 = outputs[i].choice.embedding_location.Y - 10;

                canvas.Children.Add(ln);
           }
        }
    }

    

    public class Choice_Desc_Pair
    {
        public Loud_Decision_Element owner;
        public Generic_Element choice { get; set; }
        public string desc { get; set; }
        public void rewire(object sender, MouseEventArgs args)
        {
            owner.curr_king.rw_loud_MouseMove(this, args);
        }
    }
}
