using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VN_Editor_KH16.BackEnd.Char_Set
{
    public class Character : Asset
    {
        public Character ()
        {
            images = new List<Tagged_Image>();
        }

        public override void print(Canvas canvas, List<string> tags)
        {
            throw new NotImplementedException();
        }
        public override int asset_type()
        {
            return 0;
        }
    }
}
