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
    public partial class DataEditor : Child_Window
    {
        public DataEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            MainWindow.new_selected_el += load_el;
        }

        public void load_el ()
        {
            if (MainWindow.selected.get_el_type() == 1)
            {
                Speaker_Name.DataContext = ((Slide_Element)MainWindow.selected).speaker;
                Speaker_Dialogue.DataContext = ((Slide_Element)MainWindow.selected).dialogue;
            }
        }
    }
}
