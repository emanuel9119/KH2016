using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class Group_Element : Generic_Element
    {
        List<Generic_Element> outputs;
        Generic_Element interior_head;

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
    }
}
