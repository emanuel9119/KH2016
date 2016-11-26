using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace VN_Editor_KH16.BackEnd.Char_Set
{
    public abstract class Asset
    {
        public string name { get; set; }
        public List<Tagged_Image> images { get; set; }

        public static implicit operator string (Asset ass)
        {
            return ass.name;
        }

        public void add_image (BitmapImage new_source)
        {
            Tagged_Image n = new Tagged_Image();
            n.img.Source = new_source;
            images.Add(n);
        }

        public abstract void print(Canvas canvas, List<string> tags);
        public abstract int asset_type();
    }
}
