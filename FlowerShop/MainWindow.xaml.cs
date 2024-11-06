﻿using FlowerShop.BLL;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        private PostService PostService = new();
        public void FillDataGrid()
        {
            PostFlowerDataGrid.ItemsSource = null;
            PostFlowerDataGrid.ItemsSource =  PostService.GetAllPosts();
        }
       

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();

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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}