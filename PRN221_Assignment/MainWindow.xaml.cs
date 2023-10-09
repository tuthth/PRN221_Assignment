using CarRental.Models;
using DAL.Repo;
using PRN221_Assignment1_WPF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN221_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerRepo cusRepo;
        public MainWindow()
        {
            InitializeComponent();
            cusRepo = new CustomerRepo();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("No username or/and password, try again");
            }
            else
            {
                Customer customer = cusRepo.GetUser(txtUsername.Text, txtPassword.Password);
                Customer admin = cusRepo.GetAdminAccount();
                if(txtUsername.Text.Equals(admin.Email) && txtPassword.Password.Equals(admin.Password))
                {
                    MessageBox.Show("Welcome back Admin");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else
                {
                    if (customer == null)
                    {
                        MessageBox.Show("Incorrect password");
                    }
                    else
                    {
                        if(customer.Email.Equals(admin.Email))
                        {
                            MessageBox.Show("Illegal account");
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Welcome back, {0}", customer.CustomerName));
                            CustomerWPF customerWPF = new CustomerWPF(customer);
                            customerWPF.Show();
                        }
                    }
                }
            }
            
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtUsername_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
