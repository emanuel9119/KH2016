using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    class Slide_Element : Generic_Element
    {
        Generic_Element output;

        Slide_Element()
        {
            output = null;
        }

        Slide_Element(Point loc)
        {
            embedding_location = loc;
        }

        public override void for_each_child(Action<Generic_Element> lambda)
        {
            lambda(output);
        }

        public override void for_each_descendant(Action<Generic_Element> lambda)
        {
            lambda(output);
            output.for_each_descendant(lambda);
        }

        public override int get_el_type()
        {
            return 1;
        }

        public List<Slide_Element> get_streak(ref Generic_Element new_head)
        {
            List<Slide_Element> returnable = new List<Slide_Element>();
            Slide_Element curr = this;

            do
            {
                returnable.Add(curr);
                if (curr.output.get_el_type() == 1 && curr.output.inputs.Count <= 1)
                    curr = (Slide_Element)curr.output;
                else {
                    new_head = curr.output;
                    curr = null;
                }
            } while (curr != null);

            return returnable;
        }

        public string speaker  { get; set; }
        public string dialogue { get; set; }
        public string dev_note { get; set; }
    }
}
