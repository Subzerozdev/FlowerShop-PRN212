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
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public DetailWindow()
        {
            InitializeComponent();
        }

        private PostService PostService = new PostService();
        private EventService EventService = new EventService();
        public Post EditedPost { get; set; } = null;
        public void FillDataCombobox()
        {
            CategoryNameCombobox.ItemsSource = EventService.GetEventRepo();
            CategoryNameCombobox.SelectedValuePath = "Id";
            CategoryNameCombobox.DisplayMemberPath = "Name";

        }

        public void FillElements(Post post)
        {

            txtPostName.Text = post.Name;
            txtDescription.Text = post.Description;
            txtThumbnail.Text = post.Thumbnail;
            txtAddress.Text = post.Address;
            txtPrice.Text = post.Price.ToString();
            txtAddress.Text = post.Address;

            StartDatePicker.SelectedDate = post.StartDate;
            EndDatePicker.SelectedDate = post.EndDate;
            CategoryNameCombobox.SelectedValue = post.CategoryId;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidateInput())
            {
                return;
            }
            Post post = new Post();
            post.Name = txtPostName.Text;
            post.Description = txtDescription.Text;
            post.Thumbnail = txtThumbnail.Text;
            post.Address = txtAddress.Text;
            post.Price = double.Parse(txtPrice.Text);
            post.Address = txtAddress.Text;
            // Doi Khanh lam phan quyen xg thi sua user id nha
            post.UserId = 1;
            post.StartDate = StartDatePicker.SelectedDate;
            post.EndDate = EndDatePicker.SelectedDate;
            post.CategoryId = int.Parse(CategoryNameCombobox.SelectedValue.ToString());

            if (EditedPost == null)
            {
                int maxID = PostService.GetAllPosts().Max(p => p.Id);
                int setID = maxID + 1;
                post.Id = setID;
                PostService.CreatePost(post);

            }
            else
            {
                post.Id = EditedPost.Id;
                PostService.UpdatePost(post);
            }
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataCombobox();

            if (EditedPost != null)
            {
                FillElements(EditedPost);

            }
        }

        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public bool ValidateInput()
        {
            //Phải chọn combobbox
            if (CategoryNameCombobox.SelectedItem == null)
            {
                MessageBox.Show("You must choose Category Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            //All field
            if (string.IsNullOrWhiteSpace(txtPostName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtThumbnail.Text) ||
                StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null || string.IsNullOrEmpty(txtPrice.Text))

            {
                MessageBox.Show("All fields are requirement", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;

            }

            // Postnamt bắt buộc phải ở trong khoảng 3-100 ký tự
            if (txtPostName.Text.Length < 3 || txtPostName.Text.Length > 100)
            {
                MessageBox.Show("Post name must in range 3-100 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }

            // Bắt kí tự đặc biệt 
            var playerNamerWords = txtPostName.Text.Split(' ');
            foreach (var word in playerNamerWords)
            {
                if (!char.IsUpper(word[0]) && !char.IsDigit(word[0]))
                {
                    MessageBox.Show("PostName must begin with the capital leter or digits", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return false;

                }
                if (word.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    MessageBox.Show("PostName can not allow with special character ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return false;

                }
            }
            return true;
        }
    }
}
