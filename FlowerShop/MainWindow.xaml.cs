using FlowerShop.BLL;
using FlowerShop.DAL.Entities;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public User CurrentAccount { get; set; }  //user gọi từ màn hình login 
        public List<Cart>? Carts { get; set; }
        private PostService postService = new();
        public int detailNumber=0;
        public List<OrderDetail>? Details { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private PostService PostService = new();

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Load()
        {
            FillDataGrid();
            Details = new List<OrderDetail>();
            Carts = new List<Cart>();
            FillCart();
        }

        private void FillDataGrid()
        {
            PostFlowerDataGrid.ItemsSource = null;
            PostFlowerDataGrid.ItemsSource = postService.GetAllPosts();
        }

        private void FillCart()
        {
            dgOrderDetail.ItemsSource = null;
            dgOrderDetail.ItemsSource = this.Carts;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Post? post = PostFlowerDataGrid.SelectedItem as Post;

            if (post != null)
            {
                Cart cart = new Cart();
                cart.Id = ++detailNumber;
                cart.Post = post;
                cart.TotalMoney = post.Price;
                this.Carts.Add(cart);

                OrderDetail detail = new OrderDetail();
                detail.PostId = post.Id;
                detail.TotalMoney=post.Price;
                this.Details.Add(detail);
                FillCart();
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            this.detailNumber = 0;
            this.Carts = null;
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Details = this.Details;
            orderWindow.ShowDialog();
            Load();
        }
    }
}