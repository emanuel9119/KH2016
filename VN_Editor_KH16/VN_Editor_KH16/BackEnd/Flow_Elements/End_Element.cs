using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class End_Element : Generic_Element
    {
        Group_Element master;
        int End_El_Num;

        End_Element()
        {
            master = null;
        }

        End_Element(Point loc)
        {
            embedding_location = loc;
        }

        public override void for_each_child(Action<Generic_Element> lambda)
        {

        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {

        }

        public override int get_el_type()
        {
            return 4;
        }
    }
}
