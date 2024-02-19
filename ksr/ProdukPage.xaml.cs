using ksr.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ProdukPage.xaml
    /// </summary>
    public partial class ProdukPage : Page
    {
        AppDatabase appDatabase = new AppDatabase();
        public List<Produk> DataProduk { get; set; }


        public ProdukPage()
        {
            InitializeComponent();
            DataContext = this;
            DataProduk = appDatabase.Produk.ToList();
        }

            private void btnhapus_Click(object sender, RoutedEventArgs e)
            {
            try
                {
                var data = datagrid.SelectedItem as Produk;
                appDatabase.Produk.RemoveRange(data);
                appDatabase.SaveChanges();
                DataProduk.Remove(data);
                datagrid.Items.Refresh();
                }

            catch (Exception)
                {
                MessageBox.Show("Maaf Terjadi Kesalahan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        private void btnsimpan_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {

                    appDatabase.Produk.AttachRange(DataProduk);
                    appDatabase.SaveChanges();
                    MessageBox.Show("sukses");
                }
                catch (Exception)
                {

                    MessageBox.Show("Periksa Data");
                }
            }
        }
    }
}
