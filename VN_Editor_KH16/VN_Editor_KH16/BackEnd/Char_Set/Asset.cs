using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VN_Editor_KH16.BackEnd.Char_Set
{
    abstract class Asset
    {
        string name;
        List<Tagged_Image> images;

        public abstract void print(Canvas canvas, List<string> tags);
    }
}
