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
    /// Interaction logic for CustomerWPF.xaml
    /// </summary>
    public partial class CustomerWPF : Window
    {
        public Customer _customer { get; set; }
        public CustomerWPF(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void btnManageProfile_Click(object sender, RoutedEventArgs e)
        {
            ManageOwnProfile manageOwnProfile = new ManageOwnProfile(_customer);
            manageOwnProfile.Show();
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            ViewTransaction viewTransaction = new ViewTransaction(_customer);
            viewTransaction.Show();
        }
    }
}
