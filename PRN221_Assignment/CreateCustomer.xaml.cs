using CarRental.Models;
using DAL.Repo;
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
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        public CustomerRepo CustomerRepo;
        public CreateCustomer()
        {
            InitializeComponent();
            CustomerRepo = new CustomerRepo();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer newCustomer = new Customer
                {
                    CustomerName = txtCustomerName.Text,
                    Telephone = txtTelephone.Text,
                    Email = txtEmail.Text,
                    CustomerBirthday = dpCustomerBirthday.SelectedDate,
                    Password = pwdPassword.Password
                };

                CustomerRepo.Add(newCustomer);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
