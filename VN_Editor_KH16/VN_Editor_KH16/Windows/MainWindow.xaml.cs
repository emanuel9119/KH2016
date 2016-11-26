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

namespace GlobeTrotter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static GlobeTrotter.WindowManager.docking_system docking_system;

        public MainWindow()
        {
            InitializeComponent();
            docking_system = new WindowManager.docking_system();
        }
        
        private void AnimMenuClicked(object sender, EventArgs e)
        {
            AnimationEditor cw = new AnimationEditor();
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
