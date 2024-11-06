using FlowerShop.BLL;
using FlowerShop.DAL.Entities;
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
    /// Interaction logic for UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        public User User { get; private set; }

        public UserForm(User? user = null)
        {
            InitializeComponent();
            User = user ?? new User(); // Create a new User if no user is provided.

            // If in edit mode, load data
            if (user != null)
            {
                LoadUserData(user);
            }
        }

        private void LoadUserData(User user)
        {
            txtUsername.Text = user.Username;
            txtPassword.Password = user.Password;
            txtFullName.Text = user.FullName;
            txtPhone.Text = user.Phone;
            txtAddress.Text = user.Address;
            txtRoleId.Text = user.RoleId?.ToString();
            chkIsActive.IsChecked = user.IsActive;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Save the input data into the User object
            User.Username = txtUsername.Text;
            User.Password = txtPassword.Password;
            User.FullName = txtFullName.Text;
            User.Phone = txtPhone.Text;
            User.Address = txtAddress.Text;
            User.RoleId = int.TryParse(txtRoleId.Text, out int roleId) ? roleId : (int?)null;
            User.IsActive = chkIsActive.IsChecked ?? false;
            User.CreatedAt = DateTime.Now;
            DialogResult = true;  // Indicate that the dialog was successful
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;  // Indicate that the dialog was canceled
            Close();
        }
    }

}
