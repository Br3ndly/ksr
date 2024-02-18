using ksr.Models;
using System.Windows;
using System.Windows.Controls;

namespace ksr
{
    /// <summary>
    /// Interaction logic for KasirPage.xaml
    /// </summary>
    public partial class KasirPage : Window
    {
        AppDatabase database = new AppDatabase();

        public List<Pelanggan> DataPelanggan { get; set; }
        public List<Produk> DataProduk{ get; set; }
        public List<DetailPenjualan> Detail { get; set; } = new List<DetailPenjualan>();
        public Penjualan Model { get; set; } = new Penjualan();
        public KasirPage()
        {
            InitializeComponent();
            tanggal.Content = $"Tanggal, {DateTime.Now.ToString("dd MMM yyyy")}";

            DataContext = this;
            DataPelanggan = database.Pelanggan.ToList();
            DataProduk = database.Produk.ToList();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            var selected = (Produk)cb.SelectedItem;
            if(selected != null)
            {
                Detail.Add(new DetailPenjualan() { Jumlah = 1, Produk = selected });
            }
            dg.Items.Refresh();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridChange();
        }

        private void bayar_TextChanged(object sender, TextChangedEventArgs e)
        {
            kembalian.Text = (Convert.ToDouble(bayar.Text) - Detail.Sum(x => x.SubTotal)).ToString();
        }

        private void dg_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gridChange();
        }

        private void dg_CurrentCellChanged(object sender, EventArgs e)
        {
            gridChange();
        }

        public void gridChange()
        {
            total.Content = Detail.Sum(x => x.SubTotal);
            total2.Text = Detail.Sum(x => x.SubTotal).ToString();
            dg.Items.Refresh();
        }

        private void btnSimpan(object sender, RoutedEventArgs e)
        {
            var penjualan = new Penjualan
            {
                Pelanggan = cmbPelanggan.SelectedItem as Pelanggan,
              Detail=Detail,
                Tanggal = DateTime.Now,
                User = UserLogin.UserYangLogin,
                TotalHarga = Detail.Sum(x => x.SubTotal)
            };


            database.Penjualan.Add(penjualan);
            database.Entry(penjualan.User).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            database.SaveChanges();

            ClearData();
        }
        private void ClearData()
        {
            cmbPelanggan.SelectedItem = null;
            Detail.Clear();
            total.Content = "0";
            total2.Text= "0";
            kembalian.Text = "0";
            bayar.Text = "0";
            dg.Items.Refresh();    

        }
    }

}
