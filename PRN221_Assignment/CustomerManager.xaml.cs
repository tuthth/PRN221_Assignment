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
    /// Interaction logic for CustomerManager.xaml
    /// </summary>
    public partial class CustomerManager : Window
    {
        public CustomerRepo _customer;
        public CustomerManager()
        {
            InitializeComponent();
            _customer = new CustomerRepo();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvCustomerList.ItemsSource = _customer.GetAll();
            HideColumn();
            cboCustomerID.ItemsSource = _customer.GetAll().Select(c => c.CustomerId);
        }
        private void HideColumn()
        {
            foreach (DataGridColumn dataGridColumn in dgvCustomerList.Columns)
            {
                if (dataGridColumn.Header.ToString() == "Password" || dataGridColumn.Header.ToString() == "RentingTransactions")
                {
                    dataGridColumn.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void cboCustomerID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedId = Int32.Parse(cboCustomerID.SelectedItem.ToString());
            Customer customer = _customer.GetUserWithId(selectedId);
            txtEmail.Text = customer.Email;
            txtName.Text = customer.CustomerName;
            txtTelephone.Text = customer.Telephone;
            dtpBirthday.Text = customer.CustomerBirthday.ToString();
            txtStatus.Text = customer.CustomerStatus.ToString();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cboCustomerID.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            int selectedCustomerId = Int32.Parse(cboCustomerID.SelectedItem.ToString());

            
            Customer existingCustomer = _customer.GetUserWithId(selectedCustomerId);

            if (existingCustomer != null)
            {
                
                existingCustomer.CustomerName = txtName.Text;
                existingCustomer.Telephone = txtTelephone.Text;
                existingCustomer.Email = txtEmail.Text;
                existingCustomer.CustomerBirthday = dtpBirthday.SelectedDate.Value;
                existingCustomer.CustomerStatus = Byte.Parse(txtStatus.Text.ToString());

                
                _customer.Update(existingCustomer);

                MessageBox.Show("Update success", "Confirmation", MessageBoxButton.OK);
                Window_Loaded(sender, e);
            }
            else
            {
                MessageBox.Show("Customer not found in the database.");
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedId;
            if (cboCustomerID.SelectedItem != null && int.TryParse(cboCustomerID.SelectedItem.ToString(), out selectedId))
            {
                Customer customer = _customer.GetUserWithId(selectedId);
                if (customer != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        customer.CustomerStatus = 1;
                        MessageBox.Show("Change status success");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
