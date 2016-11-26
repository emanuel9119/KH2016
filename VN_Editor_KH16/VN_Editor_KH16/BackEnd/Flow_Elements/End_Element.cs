using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class End_Element : Generic_Element
    {
        Group_Element master;
        int End_El_Num;


        public override void for_each_child(Action<Generic_Element> lambda)
        {

        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {

        }
    }
}
