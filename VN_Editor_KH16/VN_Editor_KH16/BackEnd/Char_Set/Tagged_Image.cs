using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VN_Editor_KH16.BackEnd.Char_Set
{
    class Tagged_Image
    {
        Image img;
        List<string> tags;

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
