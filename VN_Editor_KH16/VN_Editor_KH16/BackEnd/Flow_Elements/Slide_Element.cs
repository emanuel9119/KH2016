using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    class Slide_Element : Generic_Element
    {

        Generic_Element output;


        public override void for_each_child(Action<Generic_Element> lambda)
        {
            lambda(output);
        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {
            lambda(output);
            output.for_each_descendant(lambda);
        }

        public string speaker  { get; set; }
        public string dialogue { get; set; }
        public string dev_note { get; set; }
    }
}
