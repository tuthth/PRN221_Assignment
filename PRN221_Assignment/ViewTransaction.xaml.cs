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
    /// Interaction logic for ViewTransaction.xaml
    /// </summary>
    public partial class ViewTransaction : Window
    {
        public Customer _customer { get; set; }
        public RentingTransactionRepo _transaction;
        public ViewTransaction(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            _transaction = new RentingTransactionRepo();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<RentingTransaction> rentingTransactions = _transaction.GetCustomerId(_customer.CustomerId);
            dtpTransactions.ItemsSource = rentingTransactions;
            HideColumn();
        }
        private void HideColumn()
        {
            foreach(DataGridColumn dataGridColumn in  dtpTransactions.Columns)
            {
                if(dataGridColumn.Header.ToString() == "Customer" || dataGridColumn.Header.ToString() == "RentingDetails")
                {
                    dataGridColumn.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
