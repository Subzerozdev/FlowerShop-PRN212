using FlowerShop.BLL;
using FlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StaffManagement.xaml
    /// </summary>
    public partial class StaffManagement : Window
    {
        private readonly UserService _userService;

        public StaffManagement()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadUserData();
        }

        private void LoadUserData()
        {
            dtgUsers.ItemsSource = _userService.GetAllUsers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newUserWindow = new UserForm();
            if (newUserWindow.ShowDialog() == true)
            {
                _userService.add(newUserWindow.User);
                LoadUserData();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUsers.SelectedItem is User selectedUser)
            {
                var updateUserWindow = new UserForm(selectedUser);
                if (updateUserWindow.ShowDialog() == true)
                {
                    _userService.update(updateUserWindow.User);
                    LoadUserData();
                }
            }
            else
            {
                MessageBox.Show("Please select a user to update.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUsers.SelectedItem is User selectedUser)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {selectedUser.Username}?",
                                             "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _userService.delete(selectedUser.Id);
                    LoadUserData();
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void dtgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
