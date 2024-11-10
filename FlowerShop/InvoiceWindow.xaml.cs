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
using FlowerShop.DAL.Entities;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public Order? Order { get; set; }
        public List<Cart>? Carts { get; set; }
        public InvoiceWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            if (Order != null)
            {
                txtOrderDate.Text = Order.OrderDate.ToString();
                txtOrderId.Text = Order.Id.ToString();
                txtPaymentMethod.Text = Order.PaymentMethod;
                txtTotalMoney.Text = Order.TotalMoney.ToString();
                dtgOrderDetail.ItemsSource = null;
                dtgOrderDetail.ItemsSource = this.Carts;
            }
            else
            {
                MessageBox.Show("Cannot get order", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
