using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public abstract class Generic_Element
    {
        public string dalet { get; set; } = "kek";

        public List<Generic_Element> inputs;
        public Point embedding_location;

        public FlowEditor curr_king;

        public int level;

        public void DragnDropLube(FlowEditor w)
        {
            curr_king = w;
        }

        public void new_selected(object sender, EventArgs e)
        {
            MainWindow.change_selected(this);
        }

        protected void sender_converter(object sender, MouseEventArgs args)
        {
            curr_king.ex_slide_MouseMove(this, args);
        }

        protected void drop_handler(object sender, DragEventArgs args)
        {
            if (args.Handled == false)
            {
                string bar = (string)args.Data.GetData("String");
                switch (bar)
                {
                    case "rw_loud":
                        break;
                }
                Panel _panel = (Panel)sender;
            }
            args.Handled = true;
        }

        public abstract void for_each_child(Action<Generic_Element> lambda);
        public abstract void for_each_descendant(Action<Generic_Element> lambda); //Warning: May fire twice
        public abstract int get_el_type();

        public abstract void print_el(ref Canvas canvas);
        public abstract void print_cn(ref Canvas canvas);
    }
}
