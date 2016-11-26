using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VN_Editor_KH16.BackEnd.Flow_Elements
{
    public abstract class Generic_Element
    {
        public List<Generic_Element> inputs;
        public Point embedding_location;

        public int level;

        public abstract void for_each_child(Action<Generic_Element> lambda);
        public abstract void for_each_descendant(Action<Generic_Element> lambda); //Warning: May fire twice
        public abstract int get_el_type();
    }
}
