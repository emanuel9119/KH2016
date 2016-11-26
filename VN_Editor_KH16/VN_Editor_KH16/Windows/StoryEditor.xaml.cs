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
    /// Interaction logic for AnimationEditor.xaml
    /// </summary>
    public partial class StoryEditor : Child_Window
    {
        List<BackEnd.Flow_Elements.Slide_Element> current_slides = new List<BackEnd.Flow_Elements.Slide_Element>();


        public StoryEditor()
        {
            InitializeComponent();
            is_docked = false;
            safe_destruction = false;

            current_slides.Add(new BackEnd.Flow_Elements.Slide_Element() { speaker="Speaker1", dialogue="first dial", dev_note="needs more dio"});
            current_slides.Add(new BackEnd.Flow_Elements.Slide_Element() { speaker = "Speaker2", dialogue = "wryyyyy", dev_note = "dio" });
            current_slides.Add(new BackEnd.Flow_Elements.Slide_Element() { speaker = "Speaker1", dialogue = "3 dial", dev_note = "needs more dio" });
            current_slides.Add(new BackEnd.Flow_Elements.Slide_Element() { speaker = "Speaker2", dialogue = "4", dev_note = "dio" });
            current_slides.Add(new BackEnd.Flow_Elements.Slide_Element() { speaker = "Speaker1", dialogue = "5 dial", dev_note = "needs more dio" });
            current_slides.Add(new BackEnd.Flow_Elements.Slide_Element() { speaker = "Speaker2", dialogue = "77", dev_note = "dio" });
            
            
            //Story_List.DataContext = current_slides[1];
        }
    }
}
