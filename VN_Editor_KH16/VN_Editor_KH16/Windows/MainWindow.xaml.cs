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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VN_Editor_KH16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void callin();
        public static event callin new_selected_el;

        public static VN_Editor_KH16.WindowManager.docking_system docking_system;

        public static BackEnd.Flow_Elements.Generic_Element selected;

        public static void change_selected(BackEnd.Flow_Elements.Generic_Element el)
        {
            selected = el;
            new_selected_el();
        }

        public MainWindow()
        {
            InitializeComponent();
            docking_system = new WindowManager.docking_system();
        }
        
        private void ResMenuClicked(object sender, EventArgs e)
        {
            ResourceEditor cw = new ResourceEditor();
            cw.ShowInTaskbar = false;
            cw.ResizeMode = ResizeMode.NoResize;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
        }

        private void StoryMenuClicked(object sender, EventArgs e)
        {
            StoryEditor cw = new StoryEditor();
            cw.ShowInTaskbar = false;
            cw.ResizeMode = ResizeMode.NoResize;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
        }

        private void FlowEditorClicked(object sender, EventArgs e)
        {
            FlowEditor cw = new FlowEditor();
            cw.ShowInTaskbar = false;
            cw.ResizeMode = ResizeMode.NoResize;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
        }


        private void DataEditorClicked(object sender, EventArgs e)
        {
            DataEditor cw = new DataEditor();
            cw.ShowInTaskbar = false;
            cw.ResizeMode = ResizeMode.NoResize;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
        }

        private void StoryHierClicked(object sender, EventArgs e)
        {
            TreeViewer cw = new TreeViewer();
            cw.ShowInTaskbar = false;
            cw.ResizeMode = ResizeMode.NoResize;
            cw.Owner = Application.Current.MainWindow;
            cw.Show();
        }

        public void Layout_Balanced(object sender, EventArgs e)
        {
            docking_system.clear();
        }

        public void Window_Moved(object sender, EventArgs e)
        {
            docking_system.enforce_sizing();
        }
    }
}
