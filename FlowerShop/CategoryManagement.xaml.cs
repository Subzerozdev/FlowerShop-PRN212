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
    /// Interaction logic for CategoryManagement.xaml
    /// </summary>
    public partial class CategoryManagement : Window
    {
        public CategoryManagement()
        {
            InitializeComponent();
        }

        private EventService _service = new();


        public User CurrentAccount { get; set; }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();


        }

        private void FillDataGrid()
        {
            CategoriesDataGrid.ItemsSource = null;
            CategoriesDataGrid.ItemsSource = _service.GetEventRepo();
        }



        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow d = new DetailWindow();
            d.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            EventCategory? selected = CategoriesDataGrid.SelectedItem as EventCategory;
            if (selected == null)
            {

                MessageBox.Show("Vui lòng lựa chọn danh mục trước khi thay đổi!!! ", "Lựa chọn danh mục!!! ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            CategoryDetailManagement d = new();
            d.EditedCate = selected;
            d.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            EventCategory? selected = CategoriesDataGrid.SelectedItem as EventCategory;
            if (selected == null)
            {

                MessageBox.Show("Vui lòng chọn danh mục mà bạn muốn xóa!!!", "Vui lòng chọn danh mục!! ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MessageBoxResult answer = MessageBox.Show("Bạn có chắc chắn muốn xóa!!", "Chắc chắn chứ?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
            {
                return;
            }

            _service.DeleteEventCategory(selected);

            FillDataGrid();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
