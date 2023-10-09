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
    /// Interaction logic for RentingManage.xaml
    /// </summary>
    public partial class RentingManage : Window
    {
        public RentingDetailRepo RentingDetailRepo;
        public RentingTransactionRepo RentingTransactionRepo;
        public RentingManage()
        {
            InitializeComponent();
            RentingTransactionRepo = new RentingTransactionRepo();
            RentingDetailRepo = new RentingDetailRepo();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgvTransactions.ItemsSource = RentingTransactionRepo.GetAll();
            dgvDetails.ItemsSource = RentingDetailRepo.GetAll();
            HiddenDetails();
            HiddenTransactions();
        }
        private void HiddenTransactions()
        {
            foreach(DataGridColumn dataGridColumn in dgvTransactions.Columns)
            {
                if(dataGridColumn.Header.ToString() == "Customer" || dataGridColumn.Header.ToString() == "RentingDetails")
                {
                    dataGridColumn.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void HiddenDetails()
        {
            foreach (DataGridColumn dataGridColumn in dgvDetails.Columns)
            {
                if (dataGridColumn.Header.ToString() == "Car" || dataGridColumn.Header.ToString() == "RentingTransactions")
                {
                    dataGridColumn.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTransaction addTransaction = new AddTransaction();
            addTransaction.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteTransaction deleteTransaction = new DeleteTransaction();
            deleteTransaction.Show();
        }
    }
}
