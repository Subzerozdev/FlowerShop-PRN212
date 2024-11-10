﻿using FlowerShop.BLL;
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
        public User? CurrentAccount { get; set; }
        public List<Cart>? Carts { get; set; }
        private PostService postService = new();
        public int detailNumber = 0;
        public List<OrderDetail>? Details { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private PostService PostService = new();

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();

            if (CurrentAccount.RoleId == 2) 
            {
                btnCategory.IsEnabled = false;
                btnOrder.IsEnabled = false;
                btnUser.IsEnabled = false;
            }
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

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.CurrentAccount = null;
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
                detail.TotalMoney = post.Price;
                this.Details.Add(detail);
                FillCart();
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Details = this.Details;
            orderWindow.Carts = this.Carts;
            orderWindow.ShowDialog();
            this.detailNumber = 0;
            Load();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryManagement d =new CategoryManagement();
            d.ShowDialog();


        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {

            PostManagement postManagement = new PostManagement();
            postManagement.CurrentAccount = this.CurrentAccount;    
            postManagement.ShowDialog();
            Load();
        }

        private void btnOrder_Click_1(object sender, RoutedEventArgs e)
        {
            OrderManagement orderManagement = new OrderManagement();
            orderManagement.ShowDialog();   
            Load();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            StaffManagement staffManagement = new StaffManagement();
            staffManagement.ShowDialog();
            Load();
        }
    }
}