using ksr.Models;
using System.Windows;

namespace ksr
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            var user = new User(); ///data yang diambil dari database
            /// ambil data dari database sesuai dengan inputan username dan password
            /// 


            ///cek kalau data ada cocokkan dengan password
            ///

            ////kalau password OK 
            ///


            ///cek privilage 
            ///
            ///kalau admin 
            ///tampilkan halaman administraotr (MainWindo)
            ///
            if(user.Privilage== Privilage.Administrator)
            {
                var winAdmin = new MainWindow();
                winAdmin.Show();

            }

            if(user.Privilage == Privilage.Kasir) {
                    //tampilkan halaman kasir 
            }


            // kalau kasir 
            //tampilkan halaman kasir



            ////halaman logint tutup


            this.Close();
        }
    }
}
