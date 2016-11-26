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
using VN_Editor_KH16.BackEnd.Char_Set;

namespace VN_Editor_KH16
{
    /// <summary>
    /// Interaction logic for AnimationEditor.xaml
    /// </summary>
    public partial class ResourceEditor : Child_Window
    {
        public class Test
        {
            public int test { get; set; }
            public string test2 { get; set; }
        }

        public ResourceEditor()
        {
            InitializeComponent();

            List<Test> Ltest = new List<Test>();
            Ltest.Add(new Test { test = 1, test2 = "blah" });
            Ltest.Add(new Test { test = 1, test2 = "blah" });
            Ltest.Add(new Test { test = 1, test2 = "blah" });

            CharList.ItemsSource = Ltest;

        }

        private void CharList_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Add code here for onclick things
            this.Content = "derp";
        }
    }
}




        /*    InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            characters.Add(new Character() { name = "Gwynn" });
            characters.Add(new Character() { name = "Stacy" });
            characters.Add(new Character() { name = "Mary"  });
            characters.Add(new Character() { name = "Jane"  });

         //   Characters.ItemsSource = characters;
        */