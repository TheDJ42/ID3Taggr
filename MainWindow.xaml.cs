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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using TagLib;

namespace ID3Taggr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                        


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void TracksDetect()
        {
            //trackCountText.Text = "Tracks: " + Convert.ToString(Count);
        }
       

        private void NumOnly(TextCompositionEventArgs e)
        {
            // Put in PreviewTextInput property for a textbox
            // Uses Regex to determine whether or not the value entered is an int
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void yearText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumOnly(e);
        }

        private void discNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumOnly(e);
        }

        private void trackNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            NumOnly(e);
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "mp3 Files (.mp3)|*.mp3|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                string[] files = openFileDialog1.FileNames;
                foreach (string file in files)
                {
                    Mp3File mp3f = new Mp3File(file);

                    mp3Files.Items.Add(mp3f);

                    //TracksDetect();

                }
            }
        }

        private void mp3Files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mp3File mf = (Mp3File)mp3Files.SelectedItem;
            // When Clicking on different items in the listview
            // the Items in the textbox will update accordingly 
            songTitleText.Text = mf.Title;
        }
    }
}
