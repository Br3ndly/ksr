using ksr.Models;
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

namespace ksr
{
    /// <summary>
    /// Interaction logic for PelangganPage.xaml
    /// </summary>
    public partial class PelangganPage : Page
    {
        AppDatabase appDatabase = new AppDatabase();
        public List<Pelanggan> DataPelanggan { get; set; }


        public PelangganPage()
        {
            InitializeComponent();
            DataContext = this;
            DataPelanggan = appDatabase.Pelanggan.ToList();
        }

        private void btntambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                appDatabase.Pelanggan.AttachRange(DataPelanggan);
                appDatabase.SaveChanges();
                MessageBox.Show("sukses");
            }
            catch (Exception)
            {

                MessageBox.Show("Periksa Data");
            }
        }

        private void btnhapus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = datagrid.SelectedItem as Pelanggan;
                appDatabase.Pelanggan.RemoveRange(data);
                appDatabase.SaveChanges();
                DataPelanggan.Remove(data);
                datagrid.Items.Refresh();
            }

            catch (Exception)
            {
                MessageBox.Show("Maaf Terjadi Kesalahan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
