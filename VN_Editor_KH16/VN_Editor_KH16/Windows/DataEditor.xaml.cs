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
using System.Text.RegularExpressions;
using VN_Editor_KH16.BackEnd.Flow_Elements;
using Microsoft.Win32;
using System.IO;

namespace VN_Editor_KH16
{
    /// <summary>
    /// Interaction logic for AnimationEditor.xaml
    /// </summary>
    public partial class DataEditor : Child_Window
    {
        List<FrameworkElement> slide_forms = new List<FrameworkElement>();
        List<FrameworkElement> decision_forms = new List<FrameworkElement>();
        List<FrameworkElement> character_forms = new List<FrameworkElement>();

        List<Canvas> canvii = new List<Canvas>();
        int selected_sub = 0;

        public DataEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            canvii.Add(c_1);
            canvii.Add(c_2);
            canvii.Add(c_3);
            canvii.Add(c_4);
            canvii.Add(c_5);
            canvii.Add(c_6);
            canvii.Add(c_7);
            canvii.Add(c_8);
            canvii.Add(c_9);

            MainWindow.new_selected_el += load_el;
            MainWindow.new_selected_as += load_as;

            slide_forms.Add(Speaker_Name);
            slide_forms.Add(Speaker_Dialogue);
            slide_forms.Add(Character_List);
            slide_forms.Add(Scene_Previewer);
            slide_forms.Add(Slide_Grid);

            decision_forms.Add(Choice_Enumerator);
            decision_forms.Add(Choice_number);

            character_forms.Add(Picture_Holder);
            character_forms.Add(Character_Name);

            close_all();
        }

        public void Load_Image_Func (object sender, EventArgs e)
        {
            OpenFileDialog load_image_dialog = new OpenFileDialog();
            if (load_image_dialog.ShowDialog() == true)
                MainWindow.selected_ass.add_image(new BitmapImage(new Uri(load_image_dialog.FileName)));

            load_as();
        }

        public void close_all ()
        {
            decision_forms.ForEach(f => { f.Focus(); });
            decision_forms.ForEach(f => { f.Visibility = Visibility.Collapsed; });

            slide_forms.ForEach(f => { f.Focus(); });
            slide_forms.ForEach(f => { f.Visibility = Visibility.Collapsed; });

            character_forms.ForEach(f => { f.Focus(); });
            character_forms.ForEach(f => { f.Visibility = Visibility.Collapsed; });
        }

        public void check_if_num (object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex num_check = new Regex("[^123]");
            e.Handled = num_check.IsMatch(e.Text);

            base.OnPreviewTextInput(e);
            Choice_Enumerator.ItemsSource = ((Loud_Decision_Element)MainWindow.selected).outputs;
        }

        public void load_as()
        {
            close_all();

            selected_sub = 0;

            if (MainWindow.selected_ass.asset_type() == 0)
            {
                refresh_char_screen();
            }
        }

        public void refresh_char_screen ()
        {
            character_forms.ForEach(f => { f.Visibility = Visibility.Visible; });
            c_1.Children.Clear();
            for (int i = 0; i < MainWindow.selected_ass.images.Count; i++)
            {
                Image img = new Image();
                img.Source = MainWindow.selected_ass.images[i].img.Source;
                img.MaxHeight = c_1.ActualHeight;
                img.MaxWidth = c_1.ActualWidth;
                img.HorizontalAlignment = HorizontalAlignment.Center;
                img.VerticalAlignment = VerticalAlignment.Center;

                if (i == selected_sub)
                    canvii[i].Background = System.Windows.Media.Brushes.LightYellow;
                else
                    canvii[i].Background = System.Windows.Media.Brushes.Transparent;

                canvii[i].Children.Add(img);
            }
            Character_Name.DataContext = MainWindow.selected_ass;
        }

        public void load_el ()
        {
            close_all();

            if (MainWindow.selected.get_el_type() == 1)
            {
                slide_forms.ForEach(f => { f.Visibility = Visibility.Visible; });
                Speaker_Name.DataContext = ((Slide_Element)MainWindow.selected);
                Speaker_Dialogue.DataContext = ((Slide_Element)MainWindow.selected);
                Character_List.ItemsSource = ResourceEditor.characters;
            }
            if (MainWindow.selected.get_el_type() == 2)
            {
                decision_forms.ForEach(f => { f.Visibility = Visibility.Visible; });
                Choice_Enumerator.ItemsSource = ((Loud_Decision_Element)MainWindow.selected).outputs;
                Choice_number.DataContext = ((Loud_Decision_Element)MainWindow.selected);
            }
        }

        public void f1(object sender, EventArgs e) { selected_sub = 0; refresh_char_screen(); }
        public void f2(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 0) selected_sub = 1; refresh_char_screen(); }
        public void f3(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 1) selected_sub = 2; refresh_char_screen(); }
        public void f4(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 2) selected_sub = 3; refresh_char_screen(); }
        public void f5(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 3) selected_sub = 4; refresh_char_screen(); }
        public void f6(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 4) selected_sub = 5; refresh_char_screen(); }
        public void f7(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 5) selected_sub = 6; refresh_char_screen(); }
        public void f8(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 6) selected_sub = 7; refresh_char_screen(); }
        public void f9(object sender, EventArgs e) { if (MainWindow.selected_ass.images.Count > 7) selected_sub = 8; refresh_char_screen(); }
    }
}
