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
using WebsiteClass;
using Microsoft.Win32;
using FileIO;
using System.Text.RegularExpressions;

namespace MikeRSS_V2
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        //values
        private static List<Website> websites = new List<Website>();
        private static List<Website> previousWebsites = new List<Website>();

        private static string defaultPath = Environment.CurrentDirectory;
        private static string fileName = defaultPath + "\\rsssaved.dat";

        //properties
        public static List<Website> PreviousWebsites { get { return previousWebsites; } set { previousWebsites = value; } }
        public static List<Website> Websites { get { return websites; } set { websites = value; } }
        public static string FileName { get { return fileName; } }


        //constructor
        public AddWindow()
        {
            InitializeComponent();
        }

        //functions
        /// <summary>
        /// gets the information from a save file for either PreviousWebsites or websites
        /// </summary>
        /// <param name="nameFile">the file that is to be loaded from</param>
        /// <param name="previous">decides to either load to PreviousWebsites(true) or websites(false)</param>
        public static void LoadFile(string nameFile, bool previous)
        {
            
            List<Website> temoparyWebsites;

            if (previous) temoparyWebsites = PreviousWebsites;
            else temoparyWebsites = websites;

            FileProcess.LoadWebsites(temoparyWebsites, nameFile);

            if (previous) PreviousWebsites = temoparyWebsites;
            else websites = temoparyWebsites;
        }

        /// <summary>
        /// Opens a OpenFileDialog and adds the websites in the file to the listView and websites list
        /// </summary>
        private void LoadFromFile()
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open saved feed";
            fDialog.Filter = "DAT Files|*.dat";
            fDialog.InitialDirectory = @"C:\";
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;
            fDialog.FileName = "RssOutput.dat";

            try
            {
                if (fDialog.ShowDialog() == true)
                {
                    websites.Clear();
                    listView.Items.Clear();
                    LoadFile(fDialog.FileName.ToString(), false);

                    for (int i = 0; i < websites.Count; i++)
                        listView.Items.Add(new { Website = websites[i].NodeChannel["title"].InnerText, URL = websites[i].NodeChannel.BaseURI });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to read file, please make sure you are\ntrying to load the correct file", "Read Error");
            }
        }

        /// <summary>
        /// populates the listview with the Website list
        /// </summary>
        public void Initalize()
        {
            for (int i = 0; i < PreviousWebsites.Count; i++)
                listView.Items.Add(new { Website = previousWebsites[i].NodeChannel["title"].InnerText, URL = previousWebsites[i].NodeChannel.BaseURI });

            websites = previousWebsites;
        }

        /// <summary>
        /// opens a SaveFileDialog and writes to the file that is chosen
        /// </summary>
        private void ExportFiles()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "DAT Files|*.dat";
            saveFile.DefaultExt = ".dat";
            saveFile.Title = "Export your feed";
            saveFile.FileName = "RssInput.dat";

            if (saveFile.ShowDialog() == true)
                FileProcess.SaveWebsites(websites, saveFile.FileName);
        }

        /// <summary>
        /// gets the string that has been entered in  the importText field and checks if it is a url then creates a website class of it 
        /// and adds it to the websites list and the listview  
        /// </summary>
        private void ImportURL()
        {
            string rss = importText.Text;
            Regex regex = new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*", RegexOptions.IgnoreCase);
            Match match = regex.Match(rss);
            if (match.Success)
            {
                Website tempWebsite = null;
                try
                {
                    tempWebsite = new Website(rss);
                }
                catch (Exception)
                {
                    MessageBox.Show("The reader could not connect to the feed \nplease check your network connection\nand make sure the URL is correct", "ERROR could not resolve URL");
                }
                if (tempWebsite != null)
                {
                    //add website to list of websites
                    websites.Add(tempWebsite);
                    //add the item to the listview
                    listView.Items.Add(new { Website = tempWebsite.NodeChannel["title"].InnerText, URL = tempWebsite.NodeChannel.BaseURI });
                }
            }
            else
            {
                MessageBox.Show("The URL was not inputted correctly", "ERROR");
            }
        }

        /// <summary>
        /// remives the item/s that is currnetly selected in the listview
        /// </summary>
        private void RemoveSelected()
        {
            int count = listView.SelectedItems.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                listView.Items.Remove(listView.SelectedItems[i]);
                websites.RemoveAt(i);
            }
        }

        //event Handelers
        private void remove_click(object sender, RoutedEventArgs e)
        {
            RemoveSelected();
        }
        private void load_click(object sender, RoutedEventArgs e)
        {
            LoadFromFile();
        }
        private void export_Click(object sender, RoutedEventArgs e)
        {
            ExportFiles();
        }
        private void accept_Click(object sender, RoutedEventArgs e)
        {
            FileProcess.SaveWebsites(websites, fileName);
            Close();
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void import_Click(object sender, RoutedEventArgs e)
        {
            ImportURL();
        }
        private void delete_Press(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                RemoveSelected();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            RemoveSelected();
        }
        private void importText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (importText.Text == "Enter URL Here")
                importText.Text = "";
        }
    }
}