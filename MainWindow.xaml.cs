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
using System.IO;

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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (Mp3File file in mp3Files.Items)
            {
                file.Album = mf.Album;
                file.Title = mf.Title;
                file.Year = mf.Year;
                file.Genre = mf.Genre;
                file.Disc = mf.Disc;
                file.Track = mf.Track;
                //Saves the file

                //configure save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.DefaultExt = ".mp3"; //default file extension
                dlg.Filter = "mp3 Files (.mp3)|*.mp3"; //filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                }

            }
        }
        



        private void TracksDetect()
        {
            //int count = mp3Files.
            //trackCountText.Text = "Tracks: " + Convert.ToString(count);
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

                    TracksDetect();

                }
            }
        }

        Mp3File mf = null;

        private void mp3Files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mf = (Mp3File)mp3Files.SelectedItem;
            // When Clicking on different items in the listview
            // the Items in the textbox will update accordingly 
            songTitleText.Text = mf.Title;
            artistText.Text = mf.Artist;
            albumText.Text = mf.Album;
            yearText.Text = Convert.ToString(mf.Year);
            genreText.Text = mf.Genre;
            discNum.Text = Convert.ToString(mf.Disc);
            trackNum.Text = Convert.ToString(mf.Track);



        }

        private void albumText_TextChanged(object sender, TextChangedEventArgs e)
        {
            mf.Album = albumText.Text;
        }

        private void songTitleText_TextChanged(object sender, TextChangedEventArgs e)
        {
            mf.Title = songTitleText.Text;

        }
        
        private void artistTitleText_TextChanged(object sender, TextChangedEventArgs e)
        {
            mf.Artist = artistText.Text;

        }
        private void yearText_TextChanged(object sender, TextChangedEventArgs e)
        {
            mf.Year = Convert.ToUInt32(yearText.Text);

        }
        
        private void genreText_TextChanged(object sender, TextChangedEventArgs e)
        {
          mf.Genre = genreText.Text;
        }
        
        private void discNum_TextChanged(object sender, TextChangedEventArgs e)
        {
          
          mf.Disc = Convert.ToUInt32(discNum.Text);
          
        }
        
        private void trackNum_TextChanged(object sender, TextChangedEventArgs e)
        {
          mf.Track = Convert.ToUInt32(trackNum.Text);
        }
        
    }
}
