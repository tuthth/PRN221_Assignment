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
    /// Interaction logic for DeleteTransaction.xaml
    /// </summary>
    public partial class DeleteTransaction : Window
    {
        public RentingDetailRepo RentingDetailRepo;
        public RentingTransactionRepo RentingTransactionRepo;
        public DeleteTransaction()
        {
            InitializeComponent();
            RentingTransactionRepo = new RentingTransactionRepo();
            RentingDetailRepo = new RentingDetailRepo();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cboTransactions.SelectedItem == null)
            {
                MessageBox.Show("Please select a transaction to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int id = Int32.Parse(cboTransactions.SelectedValue.ToString());

            MessageBoxResult confirmationResult = MessageBox.Show("Are you sure you want to delete this transaction and its details?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmationResult == MessageBoxResult.Yes)
            {
                RentingTransaction transaction = RentingTransactionRepo.GetTransactionId(id);
                List<RentingDetail> rentingDetails = RentingDetailRepo.GetListRTId(id).ToList();

                RentingTransactionRepo.Delete(transaction);
                foreach (var detail in rentingDetails)
                {
                    RentingDetailRepo.Remove(detail);
                }

                MessageBox.Show("Transaction and associated details deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboTransactions.ItemsSource = RentingTransactionRepo.GetAll().Select(c => c.RentingTransationId);
        }
    }
}
