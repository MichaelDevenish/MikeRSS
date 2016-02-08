
using System.Windows;
using System.Diagnostics;
using System.Windows.Navigation;

namespace MikeRSS_V2
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
