using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobeTrotter.WindowManager
{
    abstract class docking_element
    {
        public float width, height, left, top;

        public abstract void enforceSizing(float new_left, float new_top, float new_width, float new_height);

        public abstract bool is_window();

        public abstract void clear();
    }
}
