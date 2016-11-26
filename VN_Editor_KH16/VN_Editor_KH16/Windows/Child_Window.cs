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
    /// Interaction logic for SceneEditor.xaml
    /// </summary>
    public partial class Child_Window : Window
    {
        protected bool has_focus;
        public bool is_docked;
        public bool safe_destruction;

        protected bool is_moving;

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!safe_destruction)
                MainWindow.docking_system.remove_window(this);
        }

        public void Window_Active(object sender, EventArgs e)
        {
            has_focus = true;
        }

        public void Window_Deactive(object sender, EventArgs e)
        {
            has_focus = false;
            is_moving = false;
        }

        public virtual void Window_Moved(object sender, EventArgs e)
        {
            if (has_focus)
            {
                MainWindow.docking_system.remove_window(this);
                this.ResizeMode = ResizeMode.CanResizeWithGrip;
                is_docked = false;
                is_moving = true;
            }
        }

        public void Window_Dropped(object sender, EventArgs e)
        {
            if (!is_docked)
                MainWindow.docking_system.add_window(this, (float)(this.Left + this.Width / 2), (float)(this.Top + 20));
            is_docked = true;
        }
    }
}
