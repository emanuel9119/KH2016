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
    public partial class TreeViewer : Child_Window
    {
        BackEnd.Flow_Elements.Group_Element header = new BackEnd.Flow_Elements.Group_Element();

        public TreeViewer()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            header.interior_head = new Slide_Element();
            ((Slide_Element)header.interior_head).output = new Loud_Decision_Element();
            ((Loud_Decision_Element)((Slide_Element)header.interior_head).output).outputs.Add(new Choice_Desc_Pair() { choice = new Slide_Element() { output = new Slide_Element() } });
            ((Loud_Decision_Element)((Slide_Element)header.interior_head).output).outputs.Add(new Choice_Desc_Pair() { choice = new Slide_Element() });

            header.get_stories(ref tree_viewer);
            return;
        }

    }
}
