using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public class Decision_Element : Generic_Element
    {
        public List<Choice_Desc_Pair> outputs;

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
    }

    public class Choice_Desc_Pair
    {
        public Generic_Element choice { get; set; }
        public string desc { get; set; }
    }
}
