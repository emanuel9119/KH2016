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

            header.add_member(new Slide_Element() { embedding_location = new Point (50,50) });
            header.add_member(new Loud_Decision_Element() { embedding_location = new Point(50, 100) });
            header.add_member(new Slide_Element() { embedding_location = new Point(50, 150) });
            header.add_member(new End_Element() { embedding_location = new Point(50, 200) });
            header.add_member(new Slide_Element() { embedding_location = new Point(100, 150) });
            header.add_member(new Slide_Element() { embedding_location = new Point(100, 200) });
            header.add_member(new End_Element() { embedding_location = new Point(100, 250) });
            header.add_member(new Slide_Element() { embedding_location = new Point(200, 200) });
            header.add_member(new Slide_Element() { embedding_location = new Point(250, 250) });

            header.interior_head = header.members[0];
            ((Slide_Element)header.members[0]).output = header.members[1];
            ((Loud_Decision_Element)header.members[1]).outputs.Add(new Choice_Desc_Pair() { choice = header.members[2] });
            ((Loud_Decision_Element)header.members[1]).outputs.Add(new Choice_Desc_Pair() { choice = header.members[4] });
            ((Slide_Element)header.members[2]).output = header.members[3];
            ((Slide_Element)header.members[4]).output = header.members[5];
            ((Slide_Element)header.members[5]).output = header.members[6];

            refresh();
            MainWindow.new_selected_el += refresh;
        }

        public void refresh ()
        {
            FlowCanv = header.print(FlowCanv);
        }
    }
}
