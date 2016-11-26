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
    public class Group_Element : Generic_Element
    {
        public List<Generic_Element> outputs;
        public List<Generic_Element> members;
        public Generic_Element interior_head;

        public Group_Element()
        {
            outputs = new List<Generic_Element>();
            members = new List<Generic_Element>();
            interior_head = null;
        }

        public Group_Element(Point loc)
        {
            embedding_location = loc;
        }

        class Node_El_Pair
        {
            public Node_El_Pair (Generic_Element e, TreeViewItem n)
            {
                El = e;
                Node = n;
            }
            public Generic_Element El;
            public TreeViewItem Node;
        };

        public void add_member (Generic_Element new_el)
        {
            if (members.Count == 0)
            {
                interior_head = new_el;
                new_el.inputs.Add(this);
            }
            members.Add(new_el);
        }

        public Canvas print (Canvas canvas)
        {
            canvas.Children.Clear();
            members.ForEach(d => d.print_cn(ref canvas));
            members.ForEach(d => d.print_el(ref canvas));
            return canvas;
        }

        public override void for_each_child(Action<Generic_Element> lambda)
        {
            outputs.ForEach(o =>
            {
                lambda(o);
            });
        }

        public void for_each_member(Action<Generic_Element> lambda)
        {
            members.ForEach(o =>
            {
                lambda(o);
            });
        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {
            outputs.ForEach(o =>
            {
                lambda(o);
                o.for_each_descendant(lambda);
            });
        }

        public void for_each_inside (Action<Generic_Element> lambda)
        {
            if (interior_head != null)
            {
                lambda(interior_head);
                interior_head.for_each_descendant(lambda);
            }
        }

        public override void print_el(ref Canvas canvas)
        {
            Polygon pic = new Polygon();

            if (this == MainWindow.selected)
                pic.Fill = System.Windows.Media.Brushes.LightYellow;
            else
                pic.Fill = System.Windows.Media.Brushes.LightCyan;

            pic.Stroke = System.Windows.Media.Brushes.Black;

            pic.Points.Add(new Point(embedding_location.X - 14, embedding_location.Y + 10));
            pic.Points.Add(new Point(embedding_location.X + 14, embedding_location.Y + 10));
            pic.Points.Add(new Point(embedding_location.X + 14, embedding_location.Y - 10));
            pic.Points.Add(new Point(embedding_location.X - 14, embedding_location.Y - 10));

            pic.MouseRightButtonDown += new_selected;
            pic.Drop += drop_handler;

            if (curr_king != null)
            {
                pic.MouseMove += sender_converter;
            }

            canvas.Children.Add(pic);
        }

        public override void print_cn(ref Canvas canvas)
        {

        }

        public override int get_el_type()
        {
            return 0;
        }
    }
}
