using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VN_Editor_KH16.BackEnd.Flow_Elements;

namespace VN_Editor_KH16
{
    /// <summary>
    /// Interaction logic for AnimationEditor.xaml
    /// </summary>
    public partial class FlowEditor : Child_Window
    {
        Group_Element header;

        public FlowEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            header.interior_head = new Slide_Element();
            ((Slide_Element)header.interior_head).output = new Loud_Decision_Element();
            ((Loud_Decision_Element)((Slide_Element)header.interior_head).output).outputs.Add(new Choice_Desc_Pair() { choice = new Slide_Element() { output = new Slide_Element() } });
            ((Loud_Decision_Element)((Slide_Element)header.interior_head).output).outputs.Add(new Choice_Desc_Pair() { choice = new Slide_Element() });

            header.print(FlowCanv);
        }
    }
}
