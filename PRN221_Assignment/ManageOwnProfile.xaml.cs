using CarRental.Models;
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

namespace PRN221_Assignment1_WPF
{
    /// <summary>
    /// Interaction logic for ManageOwnProfile.xaml
    /// </summary>
    public partial class ManageOwnProfile : Window
    {
        public Customer _customer;
        public ManageOwnProfile(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.Text = _customer.CustomerId.ToString();
            txtName.Text = _customer.CustomerName;
            txtTelephone.Text = _customer.Telephone;
            txtEmail.Text = _customer.Email;
            dtpBirthday.Text = _customer.CustomerBirthday.ToString();
            txtPassword.Password = _customer.Password;

        }
    }
}
