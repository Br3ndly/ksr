using ksr.Models;
using Microsoft.EntityFrameworkCore.Storage;
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
            try
            {
                using var appdatabase = new AppDatabase();
                var user = appdatabase.User.Where(x => x.UserName == this.TextBoxUsername.Text).FirstOrDefault();
                if (user != null && user.Password == this.PasswordBoxPass.Password)
                {
                    if (user.Previlage == Privilage.Administrator)
                    {
                        var adminpage = new MainWindow();
                        adminpage.Show();
                    }
                    else
                    {
                            var kasirpage = new KasirPage();
                            kasirpage.Show();
                    }

                    UserLogin.UserYangLogin = user;
                    this.Close();
                }
                else
            {
                var winAdmin = new MainWindow();
                winAdmin.Show();

                    throw new SystemException();
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Anda tidak memiliki akses !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            // kalau kasir 
            //tampilkan halaman kasir



            ////halaman logint tutup


            this.Close();
        }
    }
}
