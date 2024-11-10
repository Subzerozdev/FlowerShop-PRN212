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
using FlowerShop.BLL;
using FlowerShop.DAL.Entities;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        private OrderService orderService = new();
        public OrderManagement()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            dtgOrder.ItemsSource = null;
            dtgOrder.ItemsSource = orderService.GetAllOrders();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int orderId = int.Parse(txtOrderId.Text);
            string customerName = txtCustomerName.Text;
            dtgOrder.ItemsSource = null;
            dtgOrder.ItemsSource = orderService.GetOrderBySearch(customerName, orderId);

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Order order = dtgOrder.SelectedItem as Order;
            if (order != null)
            {
                order.Status = "Thành công";
                orderService.UpdateOrder(order);
            }
            FillDataGrid();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
