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

namespace FlowerShop
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private OrderService orderService = new();
        public List<OrderDetail>? Details { get; set; }
        public OrderWindow()
        {
            InitializeComponent();
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            // Email, Address, Phone and Payment must not be null or invalid
            string email = txtEmail.Text.Trim();
            if (IsStringValueValid(email))
            {
                NotValidErrorMessage("Email");
                return;
            }
            string address = txtAddress.Text.Trim();
            if (IsStringValueValid(address))
            {
                NotValidErrorMessage("Address");
                return;
            }
            string phone = txtPhone.Text.Trim();
            if (IsStringValueValid(phone)
                || !IsPhoneNumber(phone))
            {
                NotValidErrorMessage("Phone");
                return;
            }
            string? payment = CheckPaymentMethod();
            if (payment == null)
            {
                NotValidErrorMessage("Payment Method");
                return;
            }

            Order order = new Order();
            order.FullName = txtFullName.Text.Trim();
            order.Address = address;
            order.Email = email;
            order.Phone = phone;
            order.Note = txtNote.Text.Trim();
            order.PaymentMethod = payment;
            order.TotalMoney = float.Parse(txtTotalMoney.Text);
            bool result = orderService.AddOrder(order, Details);
            if (result)
            {
                SuccessMessage("Order");
                this.Hide();
            }
            else
            {
                ErrorMessage();
            }

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
