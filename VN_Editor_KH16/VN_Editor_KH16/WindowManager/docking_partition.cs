using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VN_Editor_KH16.WindowManager
{
    struct f_el_pair
    {
        public docking_element el;
        public float  partition_placement;
    }

    class docking_partition : docking_element
    {
        docking_element parent;
        List<f_el_pair> children = new List<f_el_pair>(0);
        bool  is_horizontal;

        public docking_partition (docking_element par_in, bool type)
        {
            is_horizontal = type;
            parent = par_in;
        }

        void rescale ()
        {
            float sum = 0;
            children.ForEach(c => {
                sum += c.partition_placement;
            });
            for (int i = 0; i < children.Count; i++)
            {
                f_el_pair temp = children[i];
                temp.partition_placement = temp.partition_placement / sum;
                children[i] = temp;
            }
        }

        public void add_child (docking_element new_child, bool side)
        {
            f_el_pair temp;

            temp.el = new_child;
            if (children.Count == 0)
                temp.partition_placement = 1;
            else
                temp.partition_placement = children[children.Count - 1].partition_placement;

            if (side)
                children.Add(temp);
            else
                children.Insert(children.Count - 1, temp);

            rescale();
        }

        public void add_child (docking_element new_child, float w_left, float w_top)
        {
            f_el_pair temp;

            temp.el = new_child;
            if (children.Count == 0)
                temp.partition_placement = 1;
            else
                temp.partition_placement = children[children.Count - 1].partition_placement;

            float sum = (is_horizontal ? top : left);

            for (int i = 0; i < children.Count; i++)
            {
                sum += children[i].partition_placement * (is_horizontal ? height : width);
                if (sum > (is_horizontal ? w_top : w_left))
                {
                    float l = (is_horizontal ? left                                           : sum - children[i].partition_placement * width);
                    float r = (is_horizontal ? left + width                                   : sum);
                    float t = (is_horizontal ? sum - children[i].partition_placement * height : top);
                    float b = (is_horizontal ? sum                                            : top + height);

                    if (!children[i].el.is_window ())
                    {
                        ((docking_partition)children[i].el).add_child(new_child, w_left, w_top);
                        break;
                    }

                    if (w_top < (t - b) * (w_left - l) / (l - r) + t)
                    {
                        if (w_top < (b - t) * (w_left - l) / (l - r) + b)
                        {
                            if (is_horizontal)
                                children.Insert(i, temp);
                            else
                            {
                                docking_element temp_child = children[i].el;
                                f_el_pair new_partition = children[i];
                                new_partition.el = new docking_partition(this, !is_horizontal);
                                ((docking_partition)new_partition.el).add_child(temp_child, true);
                                ((docking_partition)new_partition.el).add_child(new_child, false);
                                children[i] = new_partition;
                            }
                        }
                        else
                        {
                            if (is_horizontal)
                            {
                                docking_element temp_child = children[i].el;
                                f_el_pair new_partition = children[i];
                                new_partition.el = new docking_partition(this, !is_horizontal);
                                ((docking_partition)new_partition.el).add_child(temp_child, true);
                                ((docking_partition)new_partition.el).add_child(new_child, true);
                                children[i] = new_partition;
                            }
                            else
                                children.Insert(i + 1, temp);
                        }
                    } else
                    {
                        if (w_top > (b - t) * (w_left - l) / (l - r) + b)
                        {
                            if (is_horizontal)
                                children.Insert(i+1, temp);
                            else
                            {
                                docking_element temp_child = children[i].el;
                                f_el_pair new_partition = children[i];
                                new_partition.el = new docking_partition(this, !is_horizontal);
                                ((docking_partition)new_partition.el).add_child(temp_child, true);
                                ((docking_partition)new_partition.el).add_child(new_child, true);
                                children[i] = new_partition;
                            }
                        }
                        else
                        {
                            if (is_horizontal)
                            {
                                docking_element temp_child = children[i].el;
                                f_el_pair new_partition = children[i];
                                new_partition.el = new docking_partition(this, !is_horizontal);
                                ((docking_partition)new_partition.el).add_child(temp_child, true);
                                ((docking_partition)new_partition.el).add_child(new_child, false);
                                children[i] = new_partition;
                            } else
                            {
                                children.Insert(i, temp);
                            }
                        }
                    }
                    break;
                }
            }
            if (children.Count == 0)
                children.Add(temp);

            rescale();
        }

        public bool remove_window (Window window)
        {
            float sum = 0;
            float window_pos = (float)(is_horizontal ? window.Top + window.Height / 2 : window.Left + window.Width / 2);
            for (int i = 0; i < children.Count; i++)
            {
                if (window_pos < (is_horizontal ? top : left) + sum + (is_horizontal ? height : width) * children [i].partition_placement)
                {
                    if (children [i].el.is_window ())
                    {
                        if (((docking_window)children[i].el).window_compare (window))
                        {
                            children.RemoveAt(i);
                        }
                    } else
                    {
                        if (((docking_partition)children[i].el).remove_window(window))
                        {
                            f_el_pair temp = children[i];
                            temp.el = ((docking_partition)children[i].el).collapse();
                            children[i] = temp;
                        }
                    }
                    break;
                }
                sum += (is_horizontal ? height : width) * children[i].partition_placement;
            }
            rescale();
            return children.Count == 1;
        }

        public docking_element collapse ()
        {
            docking_element temp = children[0].el;
            children.Clear();
            return temp;
        }

        public override void enforceSizing(float new_left, float new_top, float new_width, float new_height)
        {
            left = new_left;
            top = new_top;
            width = new_width;
            height = new_height;

            float sum = 0;
            for (int i = 0; i < children.Count; i++) {
                children [i].el.enforceSizing (left + (is_horizontal ? 0 : sum), top + (is_horizontal ? sum : 0), 
                    (is_horizontal ? 1 : children[i].partition_placement) * width, (is_horizontal ? children[i].partition_placement : 1) * height);

                sum += (is_horizontal ? height * children[i].partition_placement : width * children[i].partition_placement);
            }
        }

        public override bool is_window ()
        {
            return false;
        }

        public override void clear()
        {
           children.ForEach(c =>
           {
               c.el.clear();
           });
        }
    }
}
