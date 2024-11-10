using FlowerShop.BLL;
using FlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for CategoryDetailManagement.xaml
    /// </summary>
    public partial class CategoryDetailManagement : Window
    {
        public CategoryDetailManagement()
        {
            InitializeComponent();
        }
        private EventService _service = new();



        public EventCategory EditedCate { get; set; } = null;

        private bool CheckVar()
        {

            if (string.IsNullOrWhiteSpace(NameCateTextBox.Text))
            {
                MessageBox.Show("Tên danh mục không được bỏ trống!!!!", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (NameCateTextBox.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên danh mục bắt đầu từ 3 kí tự ", "Length required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string catename = NameCateTextBox.Text.Trim();

            catename = textInfo.ToTitleCase(catename.ToLower());


            return true;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {


            if (!CheckVar()) return;


            EventCategory x = new();
            x.Id = int.Parse(CateIdTextBox.Text);
            x.Name = NameCateTextBox.Text;


            if (EditedCate == null)
            {
                _service.AddEventCategory(x);
            }
            else
            {
                _service.UpdateEventCategory(x);
            }



            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FillElements(EditedCate);

            if (EditedCate != null)
            {
                DetailWindowModeLabel.Content = "Cập nhật danh mục";
            }
            else
            {
                DetailWindowModeLabel.Content = "Tạo mới danh mục";
            }
        }

        private void FillElements(EventCategory x)
        {
            if (x == null) return;



            CateIdTextBox.Text = x.Id.ToString();
            NameCateTextBox.Text = x.Name;


        }




        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
