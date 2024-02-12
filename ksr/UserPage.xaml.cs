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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        AppDatabase appDatabase = new AppDatabase();
        public List<User> DataUser { get; set; }


        public UserPage()
        {
            InitializeComponent();
            DataContext = this;
            DataUser = appDatabase.User.ToList();
        }

        private void btnsimpan_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                appDatabase.User.AttachRange(DataUser);
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
                var data = datagrid.SelectedItem as User;
                appDatabase.User.RemoveRange(data);
                appDatabase.SaveChanges();
                DataUser.Remove(data);
                datagrid.Items.Refresh();
            }

            catch (Exception)
            {
                MessageBox.Show("Maaf Terjadi Kesalahan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
