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
        static public List<Character> characters = new List<Character>();

        public ResourceEditor()
        {
            InitializeComponent();

            CharList.ItemsSource = characters;

        }

        void new_char (object sender, EventArgs args)
        {
            characters.Add(new Character { name = "New Character" });
            CharList.ItemsSource = null;
            CharList.ItemsSource = characters;
        }

        void new_sett(object sender, EventArgs args)
        {
            characters.Add(new Character { name = "New Character" });
        }

        private void CharList_IsMouseCapturedChanged(object sender, EventArgs e)
        {
            MainWindow.change_selected_as(characters[CharList.SelectedIndex]);
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