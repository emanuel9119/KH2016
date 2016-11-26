using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VN_Editor_KH16.BackEnd.Char_Set
{
    public class Tagged_Image
    {
        public Image img = new Image();
        public List<string> tags = new List<string>();

        public int similarity(List<string> otags)
        {
            int tally = 0;
            for (int i = 0; i < tags.Count; i++)
            {
                for (int j = 0; j < otags.Count; j++)
                {
                    if (tags[i] == otags[j])
                    {
                        tally++;
                        break;
                    }
                }
            }
            return tally;
        }
    }
}
