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
        Group_Element header = new Group_Element();

        public FlowEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            header.interior_head = new Slide_Element() { embedding_location = new Point(50, 50) };
            ((Slide_Element)header.interior_head).output = new Loud_Decision_Element() { embedding_location = new Point(50, 100) };
            ((Loud_Decision_Element)((Slide_Element)header.interior_head).output).outputs.Add(new Choice_Desc_Pair() { choice = new Slide_Element() { output = new Slide_Element() { embedding_location = new Point(50, 200) } , embedding_location = new Point(50, 150) } });
            ((Loud_Decision_Element)((Slide_Element)header.interior_head).output).outputs.Add(new Choice_Desc_Pair() { choice = new Slide_Element() { embedding_location = new Point(100, 150) } });

            refresh();
            MainWindow.new_selected_el += refresh;
        }

        public void refresh ()
        {
            FlowCanv = header.print(FlowCanv);
        }
    }
}
