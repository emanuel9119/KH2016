using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class Group_Element : Generic_Element
    {
        List<Generic_Element> outputs;
        Generic_Element interior_head;

        public Group_Element()
        {
            outputs = new List<Generic_Element>();
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

        public TreeView get_stories ()
        {
            TreeView returnable = new TreeView();

            Stack<Node_El_Pair> todo_list = new Stack<Node_El_Pair>();
            List<Generic_Element> buffer = new List<Generic_Element>();
            todo_list.Push(new Node_El_Pair(interior_head, null));

            while (todo_list.Count > 0)
            {
                buffer.Clear();
                Node_El_Pair parent = todo_list.Pop();
                parent.El.for_each_child(c => buffer.Add(c));

                buffer.ForEach(e =>
                {
                    if (e.get_el_type() == 1)
                    {
                        Generic_Element next_thing = null;
                        List<Slide_Element> new_list = ((Slide_Element)e).get_streak(ref next_thing);
                        TreeViewItem new_item = new TreeViewItem();
                        new_item.Items.Add(new_list);
                        parent.Node.Items.Add(new_item);

                        if (next_thing != null)
                        {
                            TreeViewItem new_item_2 = new TreeViewItem();
                            new_item.Items.Add(new_item_2);
                            todo_list.Push(new Node_El_Pair(next_thing, new_item_2));
                        }
                    }else if (e.get_el_type() != 4)
                    {
                        TreeViewItem new_item = new TreeViewItem();
                        parent.Node.Items.Add(new_item);
                        e.for_each_child(c => todo_list.Push(new Node_El_Pair(c, new_item)));
                    }
                });
            }

            return returnable;
        }

        public override void for_each_child(Action<Generic_Element> lambda)
        {
            outputs.ForEach(o =>
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

        public override int get_el_type()
        {
            return 0;
        }
    }
}
