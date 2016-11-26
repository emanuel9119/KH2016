using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GlobeTrotter.WindowManager
{
    public class docking_system
    {
        private docking_element head;
        float left, top, width, height, actual_width, actual_height;

        public docking_system ()
        {

        }

        public void clear ()
        {
            if (head != null)
                head.clear();
            head = null;
        }

        public void enforce_sizing ()
        {

            left = Application.Current.MainWindow.WindowState == WindowState.Maximized ? -8 : (float)Application.Current.MainWindow.Left;
            top  = Application.Current.MainWindow.WindowState == WindowState.Maximized ? 48 : (float)Application.Current.MainWindow.Top + 16;
            width  = (float)Application.Current.MainWindow.ActualWidth;
            height = (float)Application.Current.MainWindow.ActualHeight - 16;
            actual_width = (float)((Grid)Application.Current.MainWindow.Content).ActualWidth;
            actual_height = (float)((Grid)Application.Current.MainWindow.Content).ActualHeight - 20;
            if (head != null)
            {
                head.enforceSizing(left + (width - actual_width) / 2, top + (height - actual_height), actual_width, actual_height - (width - actual_width) / 2);
            }
        }

        public void remove_window (Window window)
        {
            if (head != null)
            {
                if (head.is_window())
                {
                    if (((docking_window)head).window_compare(window))
                        head = null;
                } else
                {
                    if (((docking_partition)head).remove_window(window))
                    {
                        head = ((docking_partition)head).collapse();
                    }
                }
            }
            enforce_sizing();
        }

        public void add_window (Window window)
        {
            add_window(window, (float)(left + width / 2), (float)(top + height / 2));
        }

        public void add_window (Window window, float w_left, float w_top)
        {
            if (w_left < left || w_left > left + width || w_top < top || w_top > top + height)
                return;

            if (head == null)
            {
                head = new docking_window(window);
            } else
            {
                if (head.is_window())
                {
                    docking_partition temp = new docking_partition(null, true);
                    temp.enforceSizing(left + (width - actual_width) / 2, top + (height - actual_height), actual_width, actual_height - (width - actual_width) / 2);
                    temp.add_child(head, 0, 0);
                    temp.add_child(new docking_window(window), w_left, w_top);
                    head = temp;
                } else
                {
                    ((docking_partition)head).add_child(new docking_window(window), w_left, w_top);
                }
            }
            enforce_sizing();
        }
    }
}
