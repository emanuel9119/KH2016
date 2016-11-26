using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VN_Editor_KH16.WindowManager
{
    class docking_window : docking_element
    {
        Window controlled_window;

        public docking_window (Window window)
        {
            controlled_window = window;
        }

        public override void enforceSizing(float new_left, float new_top, float new_width, float new_height)
        {
            left = new_left;
            top = new_top;
            width = new_width;
            height = new_height;

            if (controlled_window != null) {
                Application.Current.MainWindow.Activate();
                controlled_window.Left = left;
                controlled_window.Top = top;
                controlled_window.Width = width;
                controlled_window.Height = Math.Max(0, height);
                controlled_window.ResizeMode = ResizeMode.NoResize;
            }
        }

        public bool window_compare (Window window)
        {
            return controlled_window == window;
        }

        public override bool is_window()
        {
            return true;
        }

        public override void clear()
        {
            ((Child_Window)controlled_window).safe_destruction = true;
            controlled_window.Close();
        }
    }
}
