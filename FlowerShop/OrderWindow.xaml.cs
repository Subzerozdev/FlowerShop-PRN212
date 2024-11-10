using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private OrderService orderService = new();
        public List<OrderDetail>? Details { get; set; }
        public List<Cart>? Carts { get; set; }
        public User? Account { get; set; }
        public OrderWindow()
        {
            InitializeComponent();
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = ValidField();
            if (!isValid) return;
            Order order = FillOrderTextBox(Account);
            int orderID = orderService.AddOrder(order, Details);
            Order? currentOrder = orderService.GetOrderById(orderID);
            if (currentOrder != null)
            {
                SuccessMessage("Order");
                this.Hide();
                InvoiceWindow invoiceWindow = new InvoiceWindow();
                invoiceWindow.Order = order;
                invoiceWindow.Carts = Carts;
                invoiceWindow.Show();
            }
            else
            {
                ErrorMessage();
            }
        }

        private bool ValidField()
        {
            bool result = true;
            string email = txtEmail.Text.Trim();
            if (IsStringValueValid(email))
            {
                NotValidErrorMessage("Email");
                result = false;
            }
            string address = txtAddress.Text.Trim();
            if (IsStringValueValid(address))
            {
                NotValidErrorMessage("Address");
                result = false;
            }
            string phone = txtPhone.Text.Trim();
            if (IsStringValueValid(phone)
                || !IsPhoneNumber(phone))
            {
                NotValidErrorMessage("Phone");
                result = false;
            }
            string? payment = CheckPaymentMethod();
            if (payment == null)
            {
                NotValidErrorMessage("Payment Method");
                result = false;
            }
            return result;
        }

        private Order FillOrderTextBox(User user)
        {
            Order order = new Order();
            order.FullName = txtFullName.Text.Trim();
            order.Address = txtAddress.Text;
            order.Email = txtEmail.Text;
            order.Phone = txtPhone.Text;
            order.Note = txtNote.Text.Trim();
            order.PaymentMethod = CheckPaymentMethod();
            order.TotalMoney = float.Parse(txtTotalMoney.Text);
            order.UserId = user.Id;
            return order;
        }

        private string? CheckPaymentMethod()
        {
            string? payment = null;
            if (rbBanking.IsChecked == true)
            {
                payment = "Banking";
            }
            else if (rbCOD.IsChecked == true)
            {
                payment = "COD";
            }
            return payment;
        }

        private bool IsStringValueValid(string value)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(value))
            {
                result = true;
            }
            return result;
        }

        private bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{10})$").Success;
        }

        private void NotValidErrorMessage(string value)
        {
            MessageBox.Show(value + " is not valid!", "Field Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SuccessMessage(string value)
        {
            MessageBox.Show(value + " is successful", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ErrorMessage()
        {
            MessageBox.Show("Something is wrong", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            double? total = 0;
            foreach (var detail in Details)
            {
                total += detail.TotalMoney;

            }
            txtTotalMoney.Text = total.ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
