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
using System.Windows.Shapes;

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
            if (selected != null)
            {
                if(Detail.Count(x => x.Produk.ID == selected.ID) > 0)
                {
                    var detail = Detail.FirstOrDefault(x => x.Produk.ID == selected.ID);
                    detail.Jumlah += 1;
                }
                else
                {
                    Detail.Add(new DetailPenjualan() { Jumlah = 1, Produk = selected });
                }
            }
            gridChange();
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

       

        public async Task gridChange()
        {
            total.Content = Detail.Sum(x => x.SubTotal);
            total2.Text = Detail.Sum(x => x.SubTotal).ToString();
            await Task.Delay(500);
            dg.Items.Refresh();
            cmbProduk.SelectedItem = null;
        }

        private void btnSimpan_click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cmbPelanggan.SelectedItem == null)
                {
                    throw new SystemException("pilih Pelanggan");
                }

                if (dg.Items.Count == 0)
                {
                    throw new SystemException("Anda belum menginput barang");
                }

                var penjualan = new Penjualan
                {
                    Pelanggan = cmbPelanggan.SelectedItem as Pelanggan,
                    Detail = Detail,
                    Tanggal = DateTime.Now,
                    User = UserLogin.UserYangLogin
                };

                database.Penjualan.Attach(penjualan);
                database.Entry(penjualan.User).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                database.SaveChanges();
                MessageBox.Show("Data berhasil disimpan");
                ClearData();
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }   
        private void ClearData()
        {
            cmbPelanggan.SelectedItem = null;
            cmbProduk.SelectedItem = null;
            Detail.Clear();
            total.Content = "0";
            total2.Text = "0";
            kembalian.Text = "0";
            bayar.Text = "0";
            dg.Items.Refresh();
        }

         private void dg_CurrentCellChanged(object sender, EventArgs e)
         {
           gridChange();
         }

        private void btnKeluar_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
