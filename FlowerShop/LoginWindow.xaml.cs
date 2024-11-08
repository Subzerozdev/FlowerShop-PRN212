using FlowerShop.BLL;
using FlowerShop.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
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

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private UserService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text.IsNullOrEmpty() || PasswordTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show(" Both Email address and password are required ", "Required fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           User ? account = _service.login(UsernameTextBox.Text, PasswordTextBox.Text);

            if (account == null)
            {
                MessageBox.Show("Invalid email address or wrong password", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MainWindow m = new();
            m.CurrentAccount = account;
            m.Show();
            this.Hide();
        }
    }
}
