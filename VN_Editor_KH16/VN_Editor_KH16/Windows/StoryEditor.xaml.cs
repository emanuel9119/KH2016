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

namespace VN_Editor_KH16
{
    /// <summary>
    /// Interaction logic for AnimationEditor.xaml
    /// </summary>
    public partial class StoryEditor : Child_Window
    {
        List<BackEnd.Flow_Elements.Slide_Element> current_slides = new List<BackEnd.Flow_Elements.Slide_Element>();
        
        public StoryEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            MainWindow.new_selected_el += check;
            Story_List.ItemsSource = current_slides;
        }

        void check()
        {
            if (MainWindow.selected.get_el_type() == 1) {
                current_slides = ((BackEnd.Flow_Elements.Slide_Element)MainWindow.selected).get_streak();
                Story_List.ItemsSource = current_slides;
            }
        }
    }
}
