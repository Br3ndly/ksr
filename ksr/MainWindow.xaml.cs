using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ksr
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

        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new HomePage());
        }

        private void btnproduk_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new ProdukPage());

        }

        private void btnpenjualan_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new PenjualanPage());

        }

        private void btnpelangan_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new PelangganPage());

        }

        private void btnuser_Click(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new UserPage());

        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}