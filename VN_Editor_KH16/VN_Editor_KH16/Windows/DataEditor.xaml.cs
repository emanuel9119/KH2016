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
        List<FrameworkElement> slide_forms = new List<FrameworkElement>();
        List<FrameworkElement> decision_forms = new List<FrameworkElement>();

        public DataEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            MainWindow.new_selected_el += load_el;

            slide_forms.Add(Speaker_Name);
            slide_forms.Add(Speaker_Dialogue);
            slide_forms.Add(Character_List);
            slide_forms.Add(Scene_Previewer);
            slide_forms.Add(Slide_Grid);

            decision_forms.Add(Choice_Enumerator);

            close_all();
        }

        public void close_all ()
        {
            decision_forms.ForEach(f => { f.Focus(); });
            decision_forms.ForEach(f => { f.Visibility = Visibility.Collapsed; });

            slide_forms.ForEach(f => { f.Focus(); });
            slide_forms.ForEach(f => { f.Visibility = Visibility.Collapsed; });
        }

        public void load_el ()
        {
            close_all();

            if (MainWindow.selected.get_el_type() == 1)
            {
                slide_forms.ForEach(f => { f.Visibility = Visibility.Visible; });
                Speaker_Name.DataContext = ((Slide_Element)MainWindow.selected);
                Speaker_Dialogue.DataContext = ((Slide_Element)MainWindow.selected);
            }
            if (MainWindow.selected.get_el_type() == 2)
            {
                decision_forms.ForEach(f => { f.Visibility = Visibility.Visible; });
                Choice_Enumerator.ItemsSource = ((Loud_Decision_Element)MainWindow.selected).outputs;
            }
        }
    }
}
