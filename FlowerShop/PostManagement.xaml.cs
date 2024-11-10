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
    /// Interaction logic for PostManagement.xaml
    /// </summary>
    public partial class PostManagement : Window
    {
        public PostManagement()
        {
            InitializeComponent();
        }

        private PostService PostService = new();
        public User? CurrentAccount { get; set; }

        public void FillDataGrid()
        {
            PostsDataGrid.ItemsSource = null;
            PostsDataGrid.ItemsSource = PostService.GetAllPosts();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();

            if (CurrentAccount.RoleId == 2)
            {
                Create_Button.IsEnabled = false;
                Update_Button.IsEnabled = false;
                Delete_Button.IsEnabled = false;
            }
        }

        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            Post? selected = PostsDataGrid.SelectedItem as Post;
            if (selected == null)
            {
                MessageBox.Show("Please select a row to update ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DetailWindow detailWindow = new DetailWindow();
                detailWindow.EditedPost = selected;
                detailWindow.ShowDialog();
                FillDataGrid();
            }

        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Post? selected = PostsDataGrid.SelectedItem as Post;

            if (selected == null)
            {
                MessageBox.Show("Please select a row to update ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you really want to delete this row", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    PostService.DeletePost(selected);
                    FillDataGrid();
                }
                else
                {
                    return;
                }
            }
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            PostsDataGrid.ItemsSource = null;
            PostsDataGrid.ItemsSource = PostService.SearchPost(PostNameSearchTextBox.Text, DescriptionSearchTextBox.Text);

        }
    }
}
