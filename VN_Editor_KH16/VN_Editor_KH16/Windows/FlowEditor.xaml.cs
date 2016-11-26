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
    public partial class FlowEditor : Child_Window
    {
        static Group_Element header = new Group_Element();

        public FlowEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            header.add_member(new Slide_Element() { embedding_location = new Point (50,50), speaker="Mary", dialogue="Oi cunt" });
            header.add_member(new Loud_Decision_Element() { embedding_location = new Point(50, 100) });
            header.add_member(new Slide_Element() { embedding_location = new Point(50, 150), speaker = "Jane", dialogue = "Yeah what" });
            header.add_member(new End_Element  () { embedding_location = new Point(50, 200) });
            header.add_member(new Slide_Element() { embedding_location = new Point(100, 150), speaker = "Mary", dialogue = "I fucked ya mum" });
            header.add_member(new Slide_Element() { embedding_location = new Point(100, 200), speaker = "Jane", dialogue = "She's dead ya dumb bitch" });
            header.add_member(new End_Element  () { embedding_location = new Point(100, 250) });
            header.add_member(new Slide_Element() { embedding_location = new Point(200, 200) });
            header.add_member(new Slide_Element() { embedding_location = new Point(250, 250) });

            header.interior_head = header.members[0];
            ((Slide_Element)header.members[0]).output = header.members[1];
            ((Loud_Decision_Element)header.members[1]).output_count = 2;
            ((Loud_Decision_Element)header.members[1]).outputs[0] = new Choice_Desc_Pair() { choice = header.members[2] };
            ((Loud_Decision_Element)header.members[1]).outputs[1] = new Choice_Desc_Pair() { choice = header.members[4] };
            ((Slide_Element)header.members[2]).output = header.members[3];
            ((Slide_Element)header.members[4]).output = header.members[5];
            ((Slide_Element)header.members[5]).output = header.members[6];

            refresh();
            MainWindow.new_selected_el += refresh;

            Polygon slide_example = new Polygon();
            slide_example.Fill = System.Windows.Media.Brushes.Salmon;
            slide_example.HorizontalAlignment = HorizontalAlignment.Left;
            slide_example.VerticalAlignment = VerticalAlignment.Top;
            slide_example.Margin = new Thickness(50, 50, 0, 0);
            slide_example.MouseMove += slide_MouseMove;
            slide_example.Points = Shapes.slide.Points;
            test2.Children.Add(slide_example);

            Polygon group_example = new Polygon();
            group_example.Fill = System.Windows.Media.Brushes.Indigo;
            group_example.HorizontalAlignment = HorizontalAlignment.Left;
            group_example.VerticalAlignment = VerticalAlignment.Top;
            group_example.Margin = new Thickness(50, 100, 0, 0);
            group_example.MouseMove += group_MouseMove;
            group_example.Points = Shapes.group.Points;
            test2.Children.Add(group_example);

            Polygon loud_example = new Polygon();
            loud_example.Fill = System.Windows.Media.Brushes.PaleVioletRed;
            loud_example.HorizontalAlignment = HorizontalAlignment.Left;
            loud_example.VerticalAlignment = VerticalAlignment.Top;
            loud_example.Margin = new Thickness(50, 150, 0, 0);
            loud_example.MouseMove += loud_MouseMove;
            loud_example.Points = Shapes.loud_decision.Points;
            test2.Children.Add(loud_example);

            Polygon end_example = new Polygon();
            end_example.Fill = System.Windows.Media.Brushes.PaleVioletRed;
            end_example.HorizontalAlignment = HorizontalAlignment.Left;
            end_example.VerticalAlignment = VerticalAlignment.Top;
            end_example.Margin = new Thickness(50, 200, 0, 0);
            end_example.MouseMove += end_MouseMove;
            end_example.Points = Shapes.end.Points;
            test2.Children.Add(end_example);

            Window_Active(null, null);
        }

        public void slide_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "slide");
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void ex_slide_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "ex_slide");
                data.SetData("Object", sender);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        //When you mouse over group object
        public void group_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "group");
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void ex_group_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "ex_group");
                data.SetData("Object", sender);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void loud_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "loud");
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void ex_loud_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "ex_loud");
                data.SetData("Object", sender);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void end_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "end");
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void ex_end_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                data.SetData("String", "ex_end");
                data.SetData("Object", sender);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }




        //When you drag object to other panel
        private void panel_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        // When you drop said obj
        private void panel_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled == false)
            {
                string bar = (string)e.Data.GetData("String");
                switch (bar)
                {
                    case "slide":
                        Slide_Element foo = new Slide_Element();
                        foo.embedding_location = e.GetPosition(FlowCanv);
                        header.add_member(foo);
                        refresh();
                        break;
                    case "ex_slide":
                    case "ex_group":
                    case "ex_end":
                    case "ex_loud":
                        ((Generic_Element)e.Data.GetData("Object")).embedding_location = e.GetPosition(FlowCanv);
                        refresh();
                        break;
                    case "group":
                        Group_Element the = new Group_Element();
                        the.embedding_location = e.GetPosition(FlowCanv);
                        header.add_member(the);
                        refresh();
                        break;
                    case "loud":
                        Loud_Decision_Element eht = new Loud_Decision_Element();
                        eht.embedding_location = e.GetPosition(FlowCanv);
                        header.add_member(eht);
                        refresh();
                        break;
                    case "end":
                        End_Element eth = new End_Element();
                        eth.embedding_location = e.GetPosition(FlowCanv);
                        header.add_member(eth);
                        refresh();
                        break;
                }
                Panel _panel = (Panel)sender;
                e.Effects = DragDropEffects.Move;
            }
            Window_Active(null, null);
        }

        public override void Window_Active(object sender, EventArgs e)
        {
            has_focus = true;
            header.for_each_member(c =>
            {
                c.DragnDropLube(this);
            });
            refresh();
        }

        public void refresh ()
        {
            FlowCanv = header.print(FlowCanv);
        }
    }
}
