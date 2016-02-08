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
using WebsiteClass;
using System.Xml;
using System.Reflection;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace MikeRSS_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //values
        private static List<string> RssComboboxSource = new List<string>();
        private static Website currentWebsite;
        private static XmlNode nodeItem;
        private static bool isLoading = true;


        //constructor
        public MainWindow()
        {
            InitializeComponent();
            AddWindow.LoadFile(AddWindow.FileName, true);
            InitalizeWindow();
        }

        //functions
        /// <summary>
        /// adds the information to the feedsView
        /// </summary>
        private void InitalizeWindow()
        {
            feedsView.Items.Clear();

            foreach (Website prevSites in AddWindow.PreviousWebsites)
                feedsView.Items.Add(new RSSFeed { Name = prevSites.NodeChannel["title"].InnerText, URL = prevSites.NodeChannel.BaseURI });
        }

        /// <summary>
        /// loads the articlesView to show the articles of the rss feed that is currently selected in the feedsView 
        /// </summary>
        private void LoadFeed()
        {
            articlesView.Items.Clear();

            string baseURL = ((RSSFeed)feedsView.SelectedItem).URL;
            int index = AddWindow.PreviousWebsites.FindIndex(f => f.NodeChannel.BaseURI == baseURL);
            currentWebsite = AddWindow.PreviousWebsites[index];

            if (currentWebsite != null)
            {
                int loopCount = 0;
                for (int i = 0; i < currentWebsite.NodeChannel.ChildNodes.Count; i++)
                {
                    if (currentWebsite.NodeChannel.ChildNodes[i].Name == "item")
                    {
                        loopCount++;

                        nodeItem = currentWebsite.NodeChannel.ChildNodes[i];
                        articlesView.Items.Add(new RSSSite { Number = loopCount.ToString() + ".", Title = nodeItem["title"].InnerText, URL = nodeItem["link"].InnerText });
                    }
                }
            }
        }

        /// <summary>
        /// mutes the script errors when loading a website
        /// </summary>
        private void HideScriptErrors()
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(webBrowser);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { true });
        }

        /// <summary>
        /// opens the currently selected item in articlesView externally
        /// </summary>
        private void OpenExternally()
        {
            if (articlesView.SelectedItems.Count != 0)
                System.Diagnostics.Process.Start(((RSSSite)articlesView.SelectedItem).URL);
            else MessageBox.Show("Please select an article", "Invalid Selection");
        }

        /// <summary>
        /// selects the next item in articlesView
        /// </summary>
        private void Next()
        {
            if (articlesView.SelectedItems.Count != 0 && articlesView.SelectedIndex + 1 != articlesView.Items.Count)
                articlesView.SelectedIndex++;
        }

        /// <summary>
        /// selects the previous item in articlesView
        /// </summary>
        private void Previous()
        {
            if (articlesView.SelectedItems.Count != 0 && articlesView.SelectedIndex + 1 != articlesView.Items.Count)
                articlesView.SelectedIndex--;
        }

        //event handelers
        private void open_Window(object sender, RoutedEventArgs e)
        {
            isLoading = false;
            AddWindow add = new AddWindow();
            add.Initalize();
            add.ShowDialog();
            AddWindow.PreviousWebsites.Clear();
            AddWindow.LoadFile(AddWindow.FileName, true);
            InitalizeWindow();
            isLoading = true;
        }
        private void about_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }
        private void openWeb_Click(object sender, RoutedEventArgs e)
        {
            OpenExternally();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Previous();
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }
        private void feedsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoading)
                LoadFeed();
        }
        private void articlesView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoading)
                webBrowser.Navigate(((RSSSite)articlesView.SelectedItem).URL);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) Previous();
            if (e.Key == Key.Right) Next();
        }
        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            progressBar.IsIndeterminate = false;
        }
        private void WebBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            progressBar.IsIndeterminate = true;
        }
        private void webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            HideScriptErrors();
        }
    }
}
